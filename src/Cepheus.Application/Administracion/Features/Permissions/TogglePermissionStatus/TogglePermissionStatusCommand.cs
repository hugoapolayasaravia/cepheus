using MediatR;

namespace Cepheus.Application.Administracion.Features.Permissions.TogglePermissionStatus
{
    public record TogglePermissionStatusCommand(int Id) : IRequest<bool>;
}
