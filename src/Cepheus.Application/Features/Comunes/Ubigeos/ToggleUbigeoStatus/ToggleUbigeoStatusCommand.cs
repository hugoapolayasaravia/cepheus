using MediatR;

namespace Cepheus.Application.Features.Comunes.Ubigeos.ToggleUbigeoStatus
{
    public record ToggleUbigeoStatusCommand(int Id) : IRequest<bool>;
}
