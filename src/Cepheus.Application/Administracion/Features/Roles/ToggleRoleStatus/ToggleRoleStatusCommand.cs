using MediatR;

namespace Cepheus.Application.Administracion.Features.Roles.ToggleRoleStatus
{
    public record ToggleRoleStatusCommand(int Id) : IRequest<bool>;
}
