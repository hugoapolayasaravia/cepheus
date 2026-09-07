using Cepheus.Application.Features.Comunes.TiposCambio.Common;
using MediatR;

namespace Cepheus.Application.Features.Comunes.TiposCambio.CreateTipoCambio
{
    public record CreateTipoCambioCommand(
        DateOnly Date,
        decimal SellRate,
        decimal BuyRate
    ) : IRequest<TipoCambioResponse>;
}
