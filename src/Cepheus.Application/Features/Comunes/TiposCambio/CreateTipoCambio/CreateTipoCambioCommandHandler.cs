using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Comunes.TiposCambio.Common;
using Cepheus.Domain.Comunes;
using MediatR;

namespace Cepheus.Application.Features.Comunes.TiposCambio.CreateTipoCambio
{
    public class CreateTipoCambioCommandHandler : IRequestHandler<CreateTipoCambioCommand, TipoCambioResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoCambioCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoCambioResponse> Handle(CreateTipoCambioCommand request, CancellationToken cancellationToken)
        {
            var tipoCambio = new TipoCambio
            {
                Date = request.Date,
                SellRate = request.SellRate,
                BuyRate = request.BuyRate
            };

            await _uow.Comunes.TiposCambio.AddAsync(tipoCambio, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(tipoCambio);
        }

        internal static TipoCambioResponse Map(TipoCambio tipoCambio) => new()
        {
            Id = tipoCambio.Id,
            Date = tipoCambio.Date,
            SellRate = tipoCambio.SellRate,
            BuyRate = tipoCambio.BuyRate,
            CreatedAt = tipoCambio.CreatedAt,
            UpdatedAt = tipoCambio.UpdatedAt,
            RowVersion = tipoCambio.RowVersion
        };
    }
}
