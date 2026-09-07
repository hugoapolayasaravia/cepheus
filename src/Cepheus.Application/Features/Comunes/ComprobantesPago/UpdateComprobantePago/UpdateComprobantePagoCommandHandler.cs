using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.ComprobantesPago.Common;
using Cepheus.Domain.Comunes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.ComprobantesPago.UpdateComprobantePago
{
    public class UpdateComprobantePagoCommandHandler : IRequestHandler<UpdateComprobantePagoCommand, ComprobantePagoResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateComprobantePagoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ComprobantePagoResponse> Handle(UpdateComprobantePagoCommand request, CancellationToken cancellationToken)
        {
            var current = await _uow.ComprobantesPago.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (current is null)
            {
                throw new KeyNotFoundException($"Comprobante de pago {request.Id} no encontrado.");
            }

            var comprobante = new ComprobantePago
            {
                Id = request.Id,
                Code = request.Code.Trim().ToUpperInvariant(),
                SunatCode = request.SunatCode.Trim(),
                Name = request.Name.Trim(),
                ShortName = request.ShortName.Trim().ToUpperInvariant(),
                Description = string.IsNullOrWhiteSpace(request.Description) ? null : request.Description.Trim(),
                RequiresRuc = request.RequiresRuc,
                RequiresAddress = request.RequiresAddress,

                IsActive = current.IsActive,
                CreatedAt = current.CreatedAt,
                CreatedBy = current.CreatedBy,

                RowVersion = request.RowVersion
            };

            _uow.ComprobantesPago.Update(comprobante);

            try
            {
                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    "El comprobante de pago fue modificado por otro proceso. Recargue los datos e intente nuevamente.");
            }

            return new ComprobantePagoResponse
            {
                Id = comprobante.Id,
                Code = comprobante.Code,
                SunatCode = comprobante.SunatCode,
                Name = comprobante.Name,
                ShortName = comprobante.ShortName,
                Description = comprobante.Description,
                RequiresRuc = comprobante.RequiresRuc,
                RequiresAddress = comprobante.RequiresAddress,
                IsActive = comprobante.IsActive,
                CreatedAt = comprobante.CreatedAt,
                UpdatedAt = comprobante.UpdatedAt,
                RowVersion = comprobante.RowVersion
            };
        }
    }
}
