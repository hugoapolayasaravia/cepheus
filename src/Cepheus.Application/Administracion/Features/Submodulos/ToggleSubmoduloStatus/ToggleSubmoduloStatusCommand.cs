using MediatR;

namespace Cepheus.Application.Administracion.Features.Submodulos.ToggleSubmoduloStatus
{
    public record ToggleSubmoduloStatusCommand(int Id) : IRequest<bool>;
}
