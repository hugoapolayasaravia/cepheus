using Cepheus.Application.Administracion.Features.Roles.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Roles.CreateRole
{
    public record CreateRoleCommand(
    string Name,
    string? Description
) : IRequest<RoleResponse>;
}
