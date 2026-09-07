using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.Monedas.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.Monedas.GetMonedaById
{
    public class GetMonedaByIdQueryHandler : IRequestHandler<GetMonedaByIdQuery, MonedaResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetMonedaByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<MonedaResponse> Handle(GetMonedaByIdQuery request, CancellationToken cancellationToken)
        {
            var moneda = await _uow.Monedas.Query()
                .AsNoTracking()
                .Where(m => m.Id == request.Id)
                .Select(m => new MonedaResponse
                {
                    Id = m.Id,
                    Code = m.Code,
                    Name = m.Name,
                    Symbol = m.Symbol,
                    NumericCode = m.NumericCode,
                    DecimalPlaces = m.DecimalPlaces,
                    IsActive = m.IsActive,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    RowVersion = m.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (moneda is null)
            {
                throw new KeyNotFoundException($"Moneda {request.Id} no encontrada.");
            }

            return moneda;
        }
    }
}
