using Cepheus.Application.Administracion.Features.Users.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.Refresh
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<AuthenticateResponse>;
}
