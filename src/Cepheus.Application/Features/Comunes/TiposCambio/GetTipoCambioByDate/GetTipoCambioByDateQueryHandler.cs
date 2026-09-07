using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.TiposCambio.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.TiposCambio.GetTipoCambioByDate
{
    public class GetTipoCambioByDateQueryHandler : IRequestHandler<GetTipoCambioByDateQuery, TipoCambioResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetTipoCambioByDateQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoCambioResponse> Handle(GetTipoCambioByDateQuery request, CancellationToken cancellationToken)
        {
            var tipoCambio = await _uow.TiposCambio.Query()
                .AsNoTracking()
                .Where(t => t.Date == request.Date)
                .Select(t => new TipoCambioResponse
                {
                    Id = t.Id,
                    Date = t.Date,
                    SellRate = t.SellRate,
                    BuyRate = t.BuyRate,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    RowVersion = t.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (tipoCambio is null)
            {
                throw new KeyNotFoundException($"No existe tipo de cambio registrado para la fecha {request.Date:yyyy-MM-dd}.");
            }

            return tipoCambio;
        }
    }
}
