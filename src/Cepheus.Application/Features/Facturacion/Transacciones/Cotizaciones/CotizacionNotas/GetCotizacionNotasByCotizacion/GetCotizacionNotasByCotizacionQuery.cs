using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionNotas.Common;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionNotas.GetCotizacionNotasByCotizacion
{
    public record GetCotizacionNotasByCotizacionQuery(
        string NegocioCode, string Year, string Month, string Code
    ) : IRequest<List<CotizacionNotaResponse>>;
}
