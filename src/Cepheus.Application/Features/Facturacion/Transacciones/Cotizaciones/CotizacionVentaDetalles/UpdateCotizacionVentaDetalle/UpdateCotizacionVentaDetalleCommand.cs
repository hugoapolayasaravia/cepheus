using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.Common;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.UpdateCotizacionDetalle
{
    public record UpdateCotizacionVentaDetalleCommand(
        string NegocioCode,
        string Year,
        string Month,
        string Code,
        int Item,
        string UnitCode,
        decimal Quantity,
        decimal UnitPrice,
        string Observations,
        int Order,
        byte[] RowVersion
    ) : IRequest<CotizacionVentaDetalleResponse>;
}
