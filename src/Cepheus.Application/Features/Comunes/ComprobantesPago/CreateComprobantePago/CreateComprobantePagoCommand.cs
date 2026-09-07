using Cepheus.Application.Features.Comunes.ComprobantesPago.Common;
using MediatR;

namespace Cepheus.Application.Features.Comunes.ComprobantesPago.CreateComprobantePago
{
    public record CreateComprobantePagoCommand(
       string Code,
       string SunatCode,
       string Name,
       string ShortName,
       string? Description,
       bool RequiresRuc,
       bool RequiresAddress
   ) : IRequest<ComprobantePagoResponse>;
}
