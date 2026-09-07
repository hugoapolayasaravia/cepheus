using Cepheus.Application.Features.Comunes.TiposCambio.Common;
using MediatR;

namespace Cepheus.Application.Features.Comunes.TiposCambio.UpdateTipoCambio
{
    public record UpdateTipoCambioCommand(
         int Id,
         DateOnly Date,
         decimal SellRate,
         decimal BuyRate,
         byte[] RowVersion
     ) : IRequest<TipoCambioResponse>;
}
