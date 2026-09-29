// Cepheus.Application/Features/Logistica/Transacciones/OrdenesCompra/CreateOrdenCompra/CreateOrdenCompraCommandValidator.cs
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Transacciones.OrdenesCompra.CreateOrdenCompra
{
    public class CreateOrdenCompraCommandValidator : AbstractValidator<CreateOrdenCompraCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateOrdenCompraCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.PlantaCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Comunes.Plantas.Query().AnyAsync(p => p.Code == c.Trim().ToUpper(), ct))
                .WithMessage("La planta indicada no existe.");

            RuleFor(x => x.TipoCompraCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Logistica.Catalogos.TiposCompra.Query().AnyAsync(t => t.Code == c.Trim().ToUpper(), ct))
                .WithMessage("El tipo de compra indicado no existe.");

            RuleFor(x => x.ComprobantePagoId)
                .MustAsync(async (id, ct) => await _uow.Comunes.ComprobantesPago.Query().AnyAsync(c => c.Id == id!.Value, ct))
                .WithMessage("El comprobante de pago indicado no existe.")
                .When(x => x.ComprobantePagoId.HasValue);

            RuleFor(x => x.ProveedorCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Logistica.Maestros.Proveedores.Query().AnyAsync(p => p.Code == c.Trim().ToUpper(), ct))
                .WithMessage("El proveedor indicado no existe.");

            RuleFor(x => x.CompradorCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Logistica.Catalogos.Compradores.Query().AnyAsync(p => p.Code == c.Trim().ToUpper(), ct))
                .WithMessage("El comprador indicado no existe.");

            RuleFor(x => x.MonedaCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Comunes.Monedas.Query().AnyAsync(m => m.Code == c.Trim().ToUpper(), ct))
                .WithMessage("La moneda indicada no existe.");

            RuleFor(x => x.LugarEnvioCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Logistica.Catalogos.LugaresEnvio.Query().AnyAsync(l => l.Code == c.Trim().ToUpper(), ct))
                .WithMessage("El lugar de envío indicado no existe.");

            RuleFor(x => x.FormaPagoCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Logistica.Catalogos.FormasPago.Query().AnyAsync(f => f.Code == c.Trim().ToUpper(), ct))
                .WithMessage("La forma de pago indicada no existe.");

            RuleFor(x => x.TramiteCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Logistica.Catalogos.Tramites.Query().AnyAsync(t => t.Code == c.Trim().ToUpper(), ct))
                .WithMessage("El trámite indicado no existe.");

            RuleFor(x => x.NotaCompraCode)
                .MustAsync(async (c, ct) => await _uow.Logistica.Catalogos.NotasCompra.Query().AnyAsync(n => n.Code == c!.Trim().ToUpper(), ct))
                .WithMessage("La nota indicada no existe.")
                .When(x => !string.IsNullOrWhiteSpace(x.NotaCompraCode));

            RuleFor(x => x.UnidadNegocioCode).Cascade(CascadeMode.Stop).NotEmpty()
                .MustAsync(async (c, ct) => await _uow.Logistica.Catalogos.UnidadesNegocio.Query().AnyAsync(u => u.Code == c.Trim().ToUpper(), ct))
                .WithMessage("La unidad de negocio indicada no existe.");

            RuleFor(x => x.FechaEntrega).GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("La fecha de entrega no puede ser anterior a la fecha del sistema.");

            RuleFor(x => x.Detalles).NotEmpty().WithMessage("La Orden de Compra debe tener al menos una línea.");

            RuleForEach(x => x.Detalles).ChildRules(line =>
            {
                line.RuleFor(l => l.ArticuloCode).Cascade(CascadeMode.Stop).NotEmpty()
                    .MustAsync(async (c, ct) => await _uow.Logistica.Maestros.Articulos.Query().AnyAsync(a => a.Code == c.Trim().ToUpper(), ct))
                    .WithMessage("El artículo indicado no existe.");

                line.RuleFor(l => l.CantidadArticulo).GreaterThan(0);
                line.RuleFor(l => l.PrecioArticulo).GreaterThanOrEqualTo(0);
                line.RuleFor(l => l.DescuentoArticulo).GreaterThanOrEqualTo(0);

                line.RuleFor(l => l.SubCentroCostoCode).Cascade(CascadeMode.Stop).NotEmpty()
                    .MustAsync(async (c, ct) => await _uow.Logistica.Maestros.SubCentrosCosto.Query().AnyAsync(s => s.Code == c.Trim().ToUpper(), ct))
                    .WithMessage("El subcentro de costo indicado no existe.");

                line.RuleForEach(l => l.Origenes).ChildRules(o =>
                    o.RuleFor(x => x.CantidadTomada).GreaterThan(0));
            });

            RuleFor(x => x)
                .MustAsync(PedidoOrigenesExist)
                .WithMessage("Alguna línea de Pedido de origen no existe en esa planta.");
        }

        private async Task<bool> PedidoOrigenesExist(CreateOrdenCompraCommand cmd, CancellationToken ct)
        {
            var plantaCode = cmd.PlantaCode.Trim().ToUpperInvariant();
            foreach (var line in cmd.Detalles)
            {
                if (line.Origenes is null) continue;
                foreach (var origen in line.Origenes)
                {
                    var exists = await _uow.Logistica.Transacciones.PedidoDetalles.Query()
                        .AnyAsync(pd => pd.PlantaCode == plantaCode
                                     && pd.PedidoCode == origen.PedidoCode.Trim().ToUpper()
                                     && pd.ItemNumber == origen.PedidoItemNumber, ct);
                    if (!exists) return false;
                }
            }
            return true;
        }
    }
}