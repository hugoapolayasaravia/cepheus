using Cepheus.Application.Administracion.Features.Programas.Common;
using Cepheus.Application.Comun.Models;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Programas.GetProgramasPaginated
{
    public class GetProgramasPaginatedQuery : PagedRequest, IRequest<PagedResult<ProgramaResponse>>
    {
        public int? SubmoduloId { get; set; }
        public string? Search { get; set; }
        public bool? IsActive { get; set; }
    }

}
