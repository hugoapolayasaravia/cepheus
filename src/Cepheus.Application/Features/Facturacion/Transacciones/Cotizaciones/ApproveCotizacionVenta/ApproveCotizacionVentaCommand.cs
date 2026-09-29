using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.Common;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.ApproveCotizacionVenta
{
    public record ApproveCotizacionVentaCommand(
        string NegocioCode, string Year, string Month, string Code
    ) : IRequest<CotizacionResponse>;
}
