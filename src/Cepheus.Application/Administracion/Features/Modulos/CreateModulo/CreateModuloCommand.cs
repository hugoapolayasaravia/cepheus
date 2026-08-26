using Cepheus.Application.Administracion.Features.Modulos.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Modulos.CreateModulo
{
    public record CreateModuloCommand(
        string Code,
        string Name,
        string? Icon,
        string? Tooltip,
        int DisplayOrder
    ) : IRequest<ModuloResponse>;


}
