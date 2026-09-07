using Cepheus.Application.Comun.Interfaces;
using MediatR;

namespace Cepheus.Application.Features.Comunes.Monedas.ToggleMonedaStatus
{
    public class ToggleMonedaStatusCommandHandler : IRequestHandler<ToggleMonedaStatusCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ToggleMonedaStatusCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ToggleMonedaStatusCommand request, CancellationToken cancellationToken)
        {
            var moneda = await _uow.Monedas.GetByIdAsync(request.Id, cancellationToken);

            if (moneda is null)
            {
                throw new KeyNotFoundException($"Moneda {request.Id} no encontrada.");
            }

            moneda.IsActive = !moneda.IsActive;

            await _uow.SaveChangesAsync(cancellationToken);

            return moneda.IsActive;
        }
    }
}
