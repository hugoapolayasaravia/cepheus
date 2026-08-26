using Cepheus.Application.Administracion.Features.Modulos.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Modulos.GetModuloById
{
    public record GetModuloByIdQuery(int Id) : IRequest<ModuloResponse>;
}
