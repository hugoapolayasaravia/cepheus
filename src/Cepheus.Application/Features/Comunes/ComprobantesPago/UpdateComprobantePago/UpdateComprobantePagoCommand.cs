using Cepheus.Application.Features.Comunes.ComprobantesPago.Common;
using MediatR;

namespace Cepheus.Application.Features.Comunes.ComprobantesPago.UpdateComprobantePago
{
    public record UpdateComprobantePagoCommand(
        int Id,
        string Code,
        string SunatCode,
        string Name,
        string ShortName,
        string? Description,
        bool RequiresRuc,
        bool RequiresAddress,
        byte[] RowVersion
    ) : IRequest<ComprobantePagoResponse>;
}
