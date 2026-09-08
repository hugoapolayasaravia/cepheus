using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.Common;
using Cepheus.Domain.Logistica.Catalogos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.UpdateUnidadMedida
{
    public class UpdateUnidadMedidaCommandHandler : IRequestHandler<UpdateUnidadMedidaCommand, UnidadMedidaResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateUnidadMedidaCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UnidadMedidaResponse> Handle(UpdateUnidadMedidaCommand request, CancellationToken cancellationToken)
        {
            var current = await _uow.UnidadesMedida.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Code == request.Code, cancellationToken);

            if (current is null)
            {
                throw new KeyNotFoundException($"Unidad de medida {request.Code} no encontrada.");
            }

            var unidad = new UnidadMedida
            {
                Code = request.Code,
                Name = request.Name.Trim(),

                IsActive = current.IsActive,
                CreatedAt = current.CreatedAt,
                CreatedBy = current.CreatedBy,

                RowVersion = request.RowVersion
            };

            _uow.UnidadesMedida.Update(unidad);

            try
            {
                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    "La unidad de medida fue modificada por otro proceso. Recargue los datos e intente nuevamente.");
            }

            return new UnidadMedidaResponse
            {
                Code = unidad.Code,
                Name = unidad.Name,
                IsActive = unidad.IsActive,
                CreatedAt = unidad.CreatedAt,
                UpdatedAt = unidad.UpdatedAt,
                RowVersion = unidad.RowVersion
            };
        }
    }
}