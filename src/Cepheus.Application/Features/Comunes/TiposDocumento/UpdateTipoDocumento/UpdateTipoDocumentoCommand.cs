using Cepheus.Application.Features.Comunes.TiposDocumento.Common;
using MediatR;

namespace Cepheus.Application.Features.Comunes.TiposDocumento.UpdateTipoDocumento
{
    public record UpdateTipoDocumentoCommand(
        string Code,
        string Name,
        string? ShortName,
        string? SunatCode,
        bool AffectsIgv,
        bool IsNonTaxable,
        bool AffectsIncomeTax,
        bool AffectsFonavi,
        bool IsService,
        bool AffectsForeignIgv,
        bool AvailableForPurchaseOrder,
        byte[] RowVersion
    ) : IRequest<TipoDocumentoResponse>;
}
