using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.Common;
using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.CreateCotizacionDetalle;
using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.UpdateCotizacionDetalle;
using Cepheus.Domain.Facturacion.Transacciones;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionDetalles.UpdateCotizacionDetalle
{
    public class UpdateCotizacionVentaDetalleCommandHandler
        : IRequestHandler<UpdateCotizacionVentaDetalleCommand, CotizacionVentaDetalleResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateCotizacionVentaDetalleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CotizacionVentaDetalleResponse> Handle(UpdateCotizacionVentaDetalleCommand request, CancellationToken cancellationToken)
        {
            var negocio = request.NegocioCode.Trim().ToUpperInvariant();
            var code = request.Code.Trim().ToUpperInvariant();

            var current = await _uow.Facturacion.Transacciones.CotizacionesDetalle.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.NegocioCode == negocio && d.Year == request.Year
                                       && d.Month == request.Month && d.Code == code && d.Item == request.Item,
                                     cancellationToken);

            if (current is null)
                throw new KeyNotFoundException($"Línea {request.Item} de la cotización {negocio}/{request.Year}/{request.Month}/{code} no encontrada.");

            var detalle = new CotizacionDetalle
            {
                NegocioCode = negocio,
                Year = request.Year,
                Month = request.Month,
                Code = code,
                Item = request.Item,

                ProductoTipoCode = current.ProductoTipoCode,
                ProductoCode = current.ProductoCode,

                UnitCode = request.UnitCode.Trim().ToUpperInvariant(),
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Observations = request.Observations.Trim(),
                Order = request.Order,
                DeliveredQuantity = current.DeliveredQuantity,

                CreatedAt = current.CreatedAt,
                CreatedBy = current.CreatedBy,

                RowVersion = request.RowVersion
            };

            _uow.Facturacion.Transacciones.CotizacionesDetalle.Update(detalle);

            try
            {
                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    "La línea fue modificada por otro proceso. Recargue los datos e intente nuevamente.");
            }

            await CotizacionVentaTotalesRecalculator.RecalculateAsync(_uow, negocio, request.Year, request.Month, code, cancellationToken);

            var reloaded = await _uow.Facturacion.Transacciones.CotizacionesDetalle.Query().AsNoTracking()
                .FirstAsync(d => d.NegocioCode == negocio && d.Year == request.Year
                              && d.Month == request.Month && d.Code == code && d.Item == request.Item, cancellationToken);

            return CreateCotizacionVentaDetalleCommandHandler.Map(reloaded);
        }
    }
}
