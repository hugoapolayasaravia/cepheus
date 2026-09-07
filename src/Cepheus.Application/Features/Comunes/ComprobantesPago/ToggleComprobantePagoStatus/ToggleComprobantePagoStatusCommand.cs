using MediatR;

namespace Cepheus.Application.Features.Comunes.ComprobantesPago.ToggleComprobantePagoStatus
{
    public record ToggleComprobantePagoStatusCommand(int Id) : IRequest<bool>;
}
