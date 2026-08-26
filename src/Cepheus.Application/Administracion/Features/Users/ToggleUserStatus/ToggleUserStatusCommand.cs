using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.ToggleUserStatus
{
    public record ToggleUserStatusCommand(int Id) : IRequest<bool>;
}
