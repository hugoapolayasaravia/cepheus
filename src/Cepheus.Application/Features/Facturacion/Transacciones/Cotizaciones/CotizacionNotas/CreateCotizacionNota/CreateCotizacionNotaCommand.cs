using Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionNotas.Common;
using Cepheus.Domain.Facturacion.Enum;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionNotas.CreateCotizacionNota
{
    public record CreateCotizacionNotaCommand(
        string NegocioCode, string Year, string Month, string Code,
        string Description, OpcionNotaCotizacion Option
    ) : IRequest<CotizacionNotaResponse>;
}
