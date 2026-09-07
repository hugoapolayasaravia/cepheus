using MediatR;

namespace Cepheus.Application.Features.Comunes.Plantas.TogglePlantaStatus
{
    public record TogglePlantaStatusCommand(int Id) : IRequest<bool>;
}
