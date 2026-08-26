using Cepheus.Application.Administracion.Features.Users.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.GetUserById
{
    public record GetUserByIdQuery(int Id) : IRequest<UserResponse>;
}
