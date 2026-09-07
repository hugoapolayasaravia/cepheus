using Cepheus.Application.Features.Comunes.MotivosDevolucion.Common;
using MediatR;

namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.UpdateMotivoDevolucion
{
    public record UpdateMotivoDevolucionCommand(
        int Id,
        string Code,
        string Name,
        bool AffectsStock,
        byte[] RowVersion
    ) : IRequest<MotivoDevolucionResponse>;
}
