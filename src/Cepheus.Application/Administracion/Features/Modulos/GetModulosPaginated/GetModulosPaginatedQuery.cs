using Cepheus.Application.Administracion.Features.Modulos.Common;
using Cepheus.Application.Comun.Models;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Modulos.GetModulosPaginated
{
    public class GetModulosPaginatedQuery : PagedRequest, IRequest<PagedResult<ModuloResponse>>
    {
        public string? Search { get; set; }
        public bool? IsActive { get; set; }
    }

}
