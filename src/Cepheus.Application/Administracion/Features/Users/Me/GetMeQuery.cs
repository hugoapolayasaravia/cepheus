using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.Me
{
    /// <summary>
    /// No recibe Id: siempre resuelve contra el usuario autenticado actual
    /// (ICurrentUserService), leído de los claims del JWT.
    /// </summary>
    public record GetMeQuery : IRequest<MeResponse>;
}
