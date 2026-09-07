using Cepheus.Application.Comun.Interfaces;
using MediatR;

namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.ToggleMotivoDevolucionStatus
{
    public class ToggleMotivoDevolucionStatusCommandHandler : IRequestHandler<ToggleMotivoDevolucionStatusCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ToggleMotivoDevolucionStatusCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ToggleMotivoDevolucionStatusCommand request, CancellationToken cancellationToken)
        {
            var motivo = await _uow.MotivosDevolucion.GetByIdAsync(request.Id, cancellationToken);

            if (motivo is null)
            {
                throw new KeyNotFoundException($"Motivo de devolución {request.Id} no encontrado.");
            }

            motivo.IsActive = !motivo.IsActive;

            await _uow.SaveChangesAsync(cancellationToken);

            return motivo.IsActive;
        }
    }
}
