using Cepheus.Application.Features.Administracion.Users.Common;
using MediatR;

namespace Cepheus.Application.Features.Administracion.Users.CreateUser
{
    public record CreateUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName
) : IRequest<UserResponse>;


}
