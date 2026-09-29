// Cepheus.Application/Features/Logistica/Transacciones/OrdenesCompra/CreateOrdenCompra/CreateOrdenCompraCommandHandler.cs
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Transacciones.OrdenesCompra.Common;
using Cepheus.Domain.Logistica.Enum;
using Cepheus.Domain.Logistica.Transacciones;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Transacciones.OrdenesCompra.CreateOrdenCompra
{
    public class CreateOrdenCompraCommandHandler : IRequestHandler<CreateOrdenCompraCommand, OrdenCompraResponse>
    {
        private const int MaxConcurrencyRetries = 3;
        private const int CorrelativeLength = 5;
        private const string CodePrefix = "5";

        private readonly IUnitOfWork _uow;

        public CreateOrdenCompraCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OrdenCompraResponse> Handle(CreateOrdenCompraCommand request, CancellationToken cancellationToken)
        {
            var plantaCode = request.PlantaCode.Trim().ToUpperInvariant();

            for (var attempt = 1; attempt <= MaxConcurrencyRetries; attempt++)
            {
                var nextCode = await NextCodeAsync(plantaCode, cancellationToken);

                var orden = new OrdenCompra
                {
                    PlantaCode = plantaCode,
                    Code = nextCode,
                    TipoCompraCode = request.TipoCompraCode.Trim().ToUpperInvariant(),
                    ComprobantePagoId = request.ComprobantePagoId,
                    FechaEntrega = request.FechaEntrega,
                    ProveedorCode = request.ProveedorCode.Trim().ToUpperInvariant(),
                    CompradorCode = request.CompradorCode.Trim().ToUpperInvariant(),
                    MonedaCode = request.MonedaCode.Trim().ToUpperInvariant(),
                    LugarEnvioCode = request.LugarEnvioCode.Trim().ToUpperInvariant(),
                    FormaPagoCode = request.FormaPagoCode.Trim().ToUpperInvariant(),
                    TramiteCode = request.TramiteCode.Trim().ToUpperInvariant(),
                    Observaciones1 = request.Observaciones1?.Trim(),
                    Observaciones2 = request.Observaciones2?.Trim(),
                    NotaCompraCode = string.IsNullOrWhiteSpace(request.NotaCompraCode) ? null : request.NotaCompraCode.Trim().ToUpperInvariant(),
                    UnidadNegocioCode = request.UnidadNegocioCode.Trim().ToUpperInvariant(),
                    EnviarCorreoProveedor = request.EnviarCorreoProveedor,
                    Estado = EstadoOrdenCompra.Pendiente,
                    NoGravableCompra = request.NoGravableCompra,
                    ServicioCompra = request.ServicioCompra,
                    IgvExteriorCompra = request.IgvExteriorCompra
                };

                var item = 1;
                var pedidoLineasAfectadas = new List<(string, string, int)>();

                foreach (var line in request.Detalles)
                {
                    var articuloCode = line.ArticuloCode.Trim().ToUpperInvariant();
                    var detalle = new OrdenCompraDetalle
                    {
                        PlantaCode = plantaCode,
                        OrdenCompraCode = nextCode,
                        ArticuloCode = articuloCode,
                        ItemNumber = item++,
                        CantidadArticulo = line.CantidadArticulo,
                        PrecioArticulo = line.PrecioArticulo,
                        DescuentoArticulo = line.DescuentoArticulo,
                        TotalArticulo = OrdenCompraTotalsCalculator.CalculateLineTotal(line.CantidadArticulo, line.PrecioArticulo, line.DescuentoArticulo),
                        SubCentroCostoCode = line.SubCentroCostoCode.Trim().ToUpperInvariant()
                    };

                    if (line.Origenes is { Count: > 0 })
                    {
                        foreach (var origen in line.Origenes)
                        {
                            var pedidoCode = origen.PedidoCode.Trim().ToUpperInvariant();
                            detalle.Origenes.Add(new OrdenCompraPedidoOrigen
                            {
                                PlantaCode = plantaCode,
                                OrdenCompraCode = nextCode,
                                ArticuloCode = articuloCode,
                                PedidoCode = pedidoCode,
                                PedidoItemNumber = origen.PedidoItemNumber,
                                CantidadTomada = origen.CantidadTomada
                            });
                            pedidoLineasAfectadas.Add((plantaCode, pedidoCode, origen.PedidoItemNumber));
                        }
                    }

                    orden.Detalles.Add(detalle);
                }

                await OrdenCompraTotalsCalculator.RecalculateAsync(_uow, orden, cancellationToken);

                await _uow.Logistica.Transacciones.OrdenesCompra.AddAsync(orden, cancellationToken);

                if (pedidoLineasAfectadas.Count > 0)
                {
                    await OrdenCompraTotalsCalculator.RecalculatePedidoCantidadEnCompraAsync(_uow, pedidoLineasAfectadas, cancellationToken);
                }

                try
                {
                    await _uow.SaveChangesAsync(cancellationToken);
                    return OrdenCompraMapper.Map(orden);
                }
                catch (DbUpdateException) when (attempt < MaxConcurrencyRetries)
                {
                    // Colisión de correlativo por creación simultánea en la misma planta.
                }
            }

            throw new InvalidOperationException(
                $"No se pudo generar el correlativo de Orden de Compra para la planta {plantaCode} por alta concurrencia. Intente nuevamente.");
        }

        private async Task<string> NextCodeAsync(string plantaCode, CancellationToken cancellationToken)
        {
            var lastCode = await _uow.Logistica.Transacciones.OrdenesCompra.Query()
                .Where(o => o.PlantaCode == plantaCode && o.Code.StartsWith(CodePrefix))
                .OrderByDescending(o => o.Code)
                .Select(o => o.Code)
                .FirstOrDefaultAsync(cancellationToken);

            var next = 1;
            if (lastCode is not null && int.TryParse(lastCode.Substring(CodePrefix.Length), out var lastNumber))
            {
                next = lastNumber + 1;
            }

            return CodePrefix + next.ToString().PadLeft(CorrelativeLength, '0');
        }
    }
}