using Cepheus.Application.Comun.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Maestros.Vehiculos.ToggleVehiculoStatus
{
    public class ToggleVehiculoStatusCommandHandler : IRequestHandler<ToggleVehiculoStatusCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ToggleVehiculoStatusCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ToggleVehiculoStatusCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = await _uow.Vehiculos.Query()
                .FirstOrDefaultAsync(v => v.Code == request.Code, cancellationToken);

            if (vehiculo is null)
            {
                throw new KeyNotFoundException($"Vehículo {request.Code} no encontrado.");
            }

            vehiculo.IsActive = !vehiculo.IsActive;

            await _uow.SaveChangesAsync(cancellationToken);

            return vehiculo.IsActive;
        }
    }
}
