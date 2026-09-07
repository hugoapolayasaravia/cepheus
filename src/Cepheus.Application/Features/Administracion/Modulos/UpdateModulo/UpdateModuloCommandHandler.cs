using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Administracion.Modulos.Common;
using Cepheus.Domain.Administracion;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Administracion.Modulos.UpdateModulo
{
    public class UpdateModuloCommandHandler : IRequestHandler<UpdateModuloCommand, ModuloResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateModuloCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ModuloResponse> Handle(UpdateModuloCommand request, CancellationToken cancellationToken)
        {
            var current = await _uow.Modulos.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

            if (current is null)
            {
                throw new KeyNotFoundException($"Módulo {request.Id} no encontrado.");
            }

            var modulo = new Modulo
            {
                Id = request.Id,
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                Icon = string.IsNullOrWhiteSpace(request.Icon) ? null : request.Icon.Trim(),
                Tooltip = string.IsNullOrWhiteSpace(request.Tooltip) ? null : request.Tooltip.Trim(),
                DisplayOrder = request.DisplayOrder,

                IsActive = current.IsActive,
                CreatedAt = current.CreatedAt,
                CreatedBy = current.CreatedBy,

                RowVersion = request.RowVersion
            };

            _uow.Modulos.Update(modulo);

            try
            {
                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    "El módulo fue modificado por otro proceso. Recargue los datos e intente nuevamente.");
            }

            return new ModuloResponse
            {
                Id = modulo.Id,
                Code = modulo.Code,
                Name = modulo.Name,
                Icon = modulo.Icon,
                Tooltip = modulo.Tooltip,
                DisplayOrder = modulo.DisplayOrder,
                IsActive = modulo.IsActive,
                CreatedAt = modulo.CreatedAt,
                UpdatedAt = modulo.UpdatedAt,
                RowVersion = modulo.RowVersion
            };
        }
    }



}
