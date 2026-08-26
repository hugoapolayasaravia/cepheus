using Cepheus.Application.Administracion.Features.Permissions.Common;
using Cepheus.Application.Comun.Models;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Permissions.GetPermissionsPaginated
{
    public class GetPermissionsPaginatedQuery : PagedRequest, IRequest<PagedResult<PermissionResponse>>
    {
        public int? ProgramaId { get; set; }
        public string? Search { get; set; }
        public bool? IsActive { get; set; }
    }

}
