using Cepheus.Application.Administracion.Features.Users.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.UpdateUser
{
    public record UpdateUserCommand(
        int Id,
        string Email,
        string FirstName,
        string LastName,
        byte[] RowVersion
    ) : IRequest<UserResponse>;
}
