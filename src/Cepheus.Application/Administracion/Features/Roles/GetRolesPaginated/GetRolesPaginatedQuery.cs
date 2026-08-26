using Cepheus.Application.Administracion.Features.Roles.Common;
using Cepheus.Application.Comun.Models;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Roles.GetRolesPaginated
{
    public class GetRolesPaginatedQuery : PagedRequest, IRequest<PagedResult<RoleResponse>>
    {
        public string? Search { get; set; }
        public bool? IsActive { get; set; }
    }

}
