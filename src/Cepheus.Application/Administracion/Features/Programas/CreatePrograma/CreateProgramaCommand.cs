using Cepheus.Application.Administracion.Features.Programas.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Programas.CreatePrograma
{
    public record CreateProgramaCommand(
        int SubmoduloId,
        string Code,
        string Name,
        string? Icon,
        string? Tooltip,
        string? Route,
        int DisplayOrder
    ) : IRequest<ProgramaResponse>;


}
