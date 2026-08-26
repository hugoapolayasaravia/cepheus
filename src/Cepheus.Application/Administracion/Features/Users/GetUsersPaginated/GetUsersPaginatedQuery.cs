using Cepheus.Application.Administracion.Features.Users.Common;
using Cepheus.Application.Comun.Models;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.GetUsersPaginated
{
    public class GetUsersPaginatedQuery : PagedRequest, IRequest<PagedResult<UserResponse>>
    {
        public string? Search { get; set; }
        public bool? IsActive { get; set; }
    }
}
