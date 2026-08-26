using Cepheus.Application.Administracion.Features.Roles.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.GetUserRoles
{
    public record GetUserRolesQuery(int UserId) : IRequest<List<RoleResponse>>;
}
