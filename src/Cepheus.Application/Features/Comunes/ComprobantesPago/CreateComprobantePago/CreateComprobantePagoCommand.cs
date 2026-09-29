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
       bool RequiresAddress,
        bool AffectsIgv,
        bool IsNonTaxable,
        bool AffectsIncomeTax,
        bool AffectsFonavi,
        bool IsService,
        bool AffectsForeignIgv,
        bool AvailableForPurchaseOrder
   ) : IRequest<ComprobantePagoResponse>;
}
