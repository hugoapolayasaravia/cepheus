using Cepheus.Application.Administracion.Features.Submodulos.Common;
using Cepheus.Application.Comun.Models;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Submodulos.GetSubmodulosPaginated
{
    public class GetSubmodulosPaginatedQuery : PagedRequest, IRequest<PagedResult<SubmoduloResponse>>
    {
        public int? ModuloId { get; set; }
        public string? Search { get; set; }
        public bool? IsActive { get; set; }
    }

}

