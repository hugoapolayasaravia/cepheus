using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.Common;
using Cepheus.Domain.Facturacion.Transacciones;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.CreateCotizacionDetalle
{
    public class CreateCotizacionVentaDetalleCommandHandler
        : IRequestHandler<CreateCotizacionVentaDetalleCommand, CotizacionVentaDetalleResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateCotizacionVentaDetalleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CotizacionVentaDetalleResponse> Handle(CreateCotizacionVentaDetalleCommand request, CancellationToken cancellationToken)
        {
            var negocio = request.NegocioCode.Trim().ToUpperInvariant();
            var code = request.Code.Trim().ToUpperInvariant();

            var detalle = new CotizacionDetalle
            {
                NegocioCode = negocio,
                Year = request.Year,
                Month = request.Month,
                Code = code,
                ProductoTipoCode = request.ProductoTipoCode.Trim().ToUpperInvariant(),
                ProductoCode = request.ProductoCode.Trim().ToUpperInvariant(),
                UnitCode = request.UnitCode.Trim().ToUpperInvariant(),
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Observations = request.Observations.Trim(),
                Order = request.Order,
                DeliveredQuantity = 0
            };

            await _uow.Facturacion.Transacciones.CotizacionesDetalle.AddAsync(detalle, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            await CotizacionVentaTotalesRecalculator.RecalculateAsync(_uow, negocio, request.Year, request.Month, code, cancellationToken);

            return Map(detalle);
        }

        internal static CotizacionVentaDetalleResponse Map(CotizacionDetalle d) => new()
        {
            NegocioCode = d.NegocioCode,
            Year = d.Year,
            Month = d.Month,
            Code = d.Code,
            Item = d.Item,
            ProductoTipoCode = d.ProductoTipoCode,
            ProductoCode = d.ProductoCode,
            UnitCode = d.UnitCode,
            Quantity = d.Quantity,
            UnitPrice = d.UnitPrice,
            Total = d.Total,
            Observations = d.Observations,
            Order = d.Order,
            DeliveredQuantity = d.DeliveredQuantity,
            CreatedAt = d.CreatedAt,
            UpdatedAt = d.UpdatedAt,
            RowVersion = d.RowVersion
        };
    }
}
