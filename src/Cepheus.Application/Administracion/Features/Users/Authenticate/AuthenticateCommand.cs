using Cepheus.Application.Administracion.Features.Users.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.Authenticate
{
    public record AuthenticateCommand(
         string Email,
         string Password
     ) : IRequest<AuthenticateResponse>;

}
