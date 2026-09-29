using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.Common;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.AnularCotizacionVenta
{
    public record AnularCotizacionVentaCommand(
        string NegocioCode, string Year, string Month, string Code, string Reason
    ) : IRequest<CotizacionResponse>;
}
