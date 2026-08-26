using Cepheus.Application.Administracion.Features.Programas.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Programas.GetProgramaById
{
    public record GetProgramaByIdQuery(int Id) : IRequest<ProgramaResponse>;
}
