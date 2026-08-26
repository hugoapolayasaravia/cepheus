using MediatR;

namespace Cepheus.Application.Administracion.Features.Modulos.ToggleModuloStatus
{
    public record ToggleModuloStatusCommand(int Id) : IRequest<bool>;
}
