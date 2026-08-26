using Cepheus.Application.Administracion.Features.Users.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.CreateUser
{
    public record CreateUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName
) : IRequest<UserResponse>;


}
