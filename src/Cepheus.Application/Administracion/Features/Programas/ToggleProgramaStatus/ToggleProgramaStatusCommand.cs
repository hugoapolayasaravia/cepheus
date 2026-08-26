using MediatR;

namespace Cepheus.Application.Administracion.Features.Programas.ToggleProgramaStatus
{
    public record ToggleProgramaStatusCommand(int Id) : IRequest<bool>;
}
