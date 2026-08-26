using Cepheus.Application.Administracion.Features.Roles.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Roles.GetRoleById
{
    public record GetRoleByIdQuery(int Id) : IRequest<RoleResponse>;
}
