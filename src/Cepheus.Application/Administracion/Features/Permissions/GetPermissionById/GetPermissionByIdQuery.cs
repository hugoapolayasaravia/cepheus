using Cepheus.Application.Administracion.Features.Permissions.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Permissions.GetPermissionById
{
    public record GetPermissionByIdQuery(int Id) : IRequest<PermissionResponse>;
}
