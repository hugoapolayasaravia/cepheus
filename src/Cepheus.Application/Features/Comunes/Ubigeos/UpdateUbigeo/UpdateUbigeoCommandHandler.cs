using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.Ubigeos.Common;
using Cepheus.Domain.Comunes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.Ubigeos.UpdateUbigeo
{
    public class UpdateUbigeoCommandHandler : IRequestHandler<UpdateUbigeoCommand, UbigeoResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateUbigeoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UbigeoResponse> Handle(UpdateUbigeoCommand request, CancellationToken cancellationToken)
        {
            var current = await _uow.Ubigeos.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (current is null)
            {
                throw new KeyNotFoundException($"Ubigeo {request.Id} no encontrado.");
            }

            var ubigeo = new Ubigeo
            {
                Id = request.Id,
                Code = request.Code.Trim(),
                Department = request.Department.Trim(),
                Province = request.Province.Trim(),
                District = request.District.Trim(),

                IsActive = current.IsActive,
                CreatedAt = current.CreatedAt,
                CreatedBy = current.CreatedBy,

                RowVersion = request.RowVersion
            };

            _uow.Ubigeos.Update(ubigeo);

            try
            {
                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    "El ubigeo fue modificado por otro proceso. Recargue los datos e intente nuevamente.");
            }

            return new UbigeoResponse
            {
                Id = ubigeo.Id,
                Code = ubigeo.Code,
                Department = ubigeo.Department,
                Province = ubigeo.Province,
                District = ubigeo.District,
                FullAddress = ubigeo.FullAddress,
                IsActive = ubigeo.IsActive,
                CreatedAt = ubigeo.CreatedAt,
                UpdatedAt = ubigeo.UpdatedAt,
                RowVersion = ubigeo.RowVersion
            };
        }
    }
}

