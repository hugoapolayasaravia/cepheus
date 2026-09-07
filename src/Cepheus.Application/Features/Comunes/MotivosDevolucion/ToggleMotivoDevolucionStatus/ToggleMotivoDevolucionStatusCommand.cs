using MediatR;

namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.ToggleMotivoDevolucionStatus
{
    public record ToggleMotivoDevolucionStatusCommand(int Id) : IRequest<bool>;
}
