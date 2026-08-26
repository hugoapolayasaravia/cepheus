using Cepheus.Application.Administracion.Features.Permissions.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Permissions.UpdatePermission
{
    /// <summary>
    /// ProgramaId NO se puede editar acá a propósito, mismo criterio que
    /// UpdateSubmodulo/UpdatePrograma.
    /// </summary>
    public record UpdatePermissionCommand(
        int Id,
        string Code,
        string Name,
        byte[] RowVersion
    ) : IRequest<PermissionResponse>;

}
