using Cepheus.Application.Comun.Interfaces;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Submodulos.ToggleSubmoduloStatus
{
    public class ToggleSubmoduloStatusCommandHandler : IRequestHandler<ToggleSubmoduloStatusCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ToggleSubmoduloStatusCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ToggleSubmoduloStatusCommand request, CancellationToken cancellationToken)
        {
            var submodulo = await _uow.Submodulos.GetByIdAsync(request.Id, cancellationToken);

            if (submodulo is null)
            {
                throw new KeyNotFoundException($"Submódulo {request.Id} no encontrado.");
            }

            submodulo.IsActive = !submodulo.IsActive;

            await _uow.SaveChangesAsync(cancellationToken);

            return submodulo.IsActive;
        }
    }

}
