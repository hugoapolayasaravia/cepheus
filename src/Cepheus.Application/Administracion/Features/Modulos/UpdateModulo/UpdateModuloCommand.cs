using Cepheus.Application.Administracion.Features.Modulos.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Modulos.UpdateModulo
{
    public record UpdateModuloCommand(
        int Id,
        string Code,
        string Name,
        string? Icon,
        string? Tooltip,
        int DisplayOrder,
        byte[] RowVersion
    ) : IRequest<ModuloResponse>;

}
