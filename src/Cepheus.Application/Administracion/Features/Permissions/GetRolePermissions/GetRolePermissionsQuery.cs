using Cepheus.Application.Administracion.Features.Permissions.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Permissions.GetRolePermissions
{
    public record GetRolePermissionsQuery(int RoleId) : IRequest<List<PermissionResponse>>;
}
