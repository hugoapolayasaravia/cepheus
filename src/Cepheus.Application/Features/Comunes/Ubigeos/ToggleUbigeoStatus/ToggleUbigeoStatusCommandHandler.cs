using Cepheus.Application.Comun.Interfaces;
using MediatR;

namespace Cepheus.Application.Features.Comunes.Ubigeos.ToggleUbigeoStatus
{
    public class ToggleUbigeoStatusCommandHandler : IRequestHandler<ToggleUbigeoStatusCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ToggleUbigeoStatusCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ToggleUbigeoStatusCommand request, CancellationToken cancellationToken)
        {
            var ubigeo = await _uow.Ubigeos.GetByIdAsync(request.Id, cancellationToken);

            if (ubigeo is null)
            {
                throw new KeyNotFoundException($"Ubigeo {request.Id} no encontrado.");
            }

            ubigeo.IsActive = !ubigeo.IsActive;

            await _uow.SaveChangesAsync(cancellationToken);

            return ubigeo.IsActive;
        }
    }
}
