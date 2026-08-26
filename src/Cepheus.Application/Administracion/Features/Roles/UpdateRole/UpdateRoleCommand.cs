using Cepheus.Application.Administracion.Features.Roles.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Roles.UpdateRole
{
    public record UpdateRoleCommand(
        int Id,
        string Name,
        string? Description,
        byte[] RowVersion
    ) : IRequest<RoleResponse>;

}
