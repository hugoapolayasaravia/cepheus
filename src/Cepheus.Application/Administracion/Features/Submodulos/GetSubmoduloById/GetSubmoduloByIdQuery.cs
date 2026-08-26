using Cepheus.Application.Administracion.Features.Submodulos.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Submodulos.GetSubmoduloById
{
    public record GetSubmoduloByIdQuery(int Id) : IRequest<SubmoduloResponse>;
}
