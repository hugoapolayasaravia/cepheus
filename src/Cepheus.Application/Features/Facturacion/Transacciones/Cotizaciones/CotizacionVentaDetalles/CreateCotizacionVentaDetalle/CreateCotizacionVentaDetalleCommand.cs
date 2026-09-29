using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.Common;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.CreateCotizacionDetalle
{
    public record CreateCotizacionVentaDetalleCommand(
        string NegocioCode,
        string Year,
        string Month,
        string Code,
        string ProductoTipoCode,
        string ProductoCode,
        string UnitCode,
        decimal Quantity,
        decimal UnitPrice,
        string Observations,
        int Order
    ) : IRequest<CotizacionVentaDetalleResponse>;
}
