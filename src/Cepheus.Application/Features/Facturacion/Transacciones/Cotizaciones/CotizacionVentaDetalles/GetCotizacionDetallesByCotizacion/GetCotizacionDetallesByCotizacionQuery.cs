using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionVentaDetalles.Common;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionDetalles.GetCotizacionDetallesByCotizacion
{
    public record GetCotizacionDetallesByCotizacionQuery(
        string NegocioCode, string Year, string Month, string Code
    ) : IRequest<List<CotizacionVentaDetalleResponse>>;
}
