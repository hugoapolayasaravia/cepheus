using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.Logout
{
    public record LogoutCommand(string RefreshToken) : IRequest;
}
