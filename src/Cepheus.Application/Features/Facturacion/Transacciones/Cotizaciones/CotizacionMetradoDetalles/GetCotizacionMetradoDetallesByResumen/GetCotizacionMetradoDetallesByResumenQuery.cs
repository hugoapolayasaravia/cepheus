using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionMetradoDetalles.Common;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionMetradoDetalles.GetCotizacionMetradoDetallesByResumen
{
    public record GetCotizacionMetradoDetallesByResumenQuery(
        string NegocioCode, string Year, string Month, string Code, int LevelNumber
    ) : IRequest<List<CotizacionMetradoDetalleResponse>>;
}
