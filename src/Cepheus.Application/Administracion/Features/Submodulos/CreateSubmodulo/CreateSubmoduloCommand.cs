using Cepheus.Application.Administracion.Features.Submodulos.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Submodulos.CreateSubmodulo
{
    public record CreateSubmoduloCommand(
        int ModuloId,
        string Code,
        string Name,
        string? Icon,
        string? Tooltip,
        int DisplayOrder
    ) : IRequest<SubmoduloResponse>;


}
