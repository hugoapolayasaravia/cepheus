using MediatR;

namespace Cepheus.Application.Features.Comunes.Monedas.ToggleMonedaStatus
{
    public record ToggleMonedaStatusCommand(int Id) : IRequest<bool>;
}
