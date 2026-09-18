using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Comunes.TiposDocumento.Common;
using Cepheus.Domain.Comunes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.TiposDocumento.UpdateTipoDocumento
{
    public class UpdateTipoDocumentoCommandHandler : IRequestHandler<UpdateTipoDocumentoCommand, TipoDocumentoResponse>
    {
        private readonly IUnitOfWork _uow;

        public UpdateTipoDocumentoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoDocumentoResponse> Handle(UpdateTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var current = await _uow.Comunes.TiposDocumento.Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Code == request.Code, cancellationToken);

            if (current is null)
            {
                throw new KeyNotFoundException($"Tipo de documento {request.Code} no encontrado.");
            }

            var tipoDocumento = new TipoDocumento
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                ShortName = string.IsNullOrWhiteSpace(request.ShortName) ? null : request.ShortName.Trim().ToUpperInvariant(),
                SunatCode = string.IsNullOrWhiteSpace(request.SunatCode) ? null : request.SunatCode.Trim(),
                AffectsIgv = request.AffectsIgv,
                IsNonTaxable = request.IsNonTaxable,
                AffectsIncomeTax = request.AffectsIncomeTax,
                AffectsFonavi = request.AffectsFonavi,
                IsService = request.IsService,
                AffectsForeignIgv = request.AffectsForeignIgv,
                AvailableForPurchaseOrder = request.AvailableForPurchaseOrder,

                IsActive = current.IsActive,
                CreatedAt = current.CreatedAt,
                CreatedBy = current.CreatedBy,

                RowVersion = request.RowVersion
            };

            _uow.Comunes.TiposDocumento.Update(tipoDocumento);

            try
            {
                await _uow.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new InvalidOperationException(
                    "El tipo de documento fue modificado por otro proceso. Recargue los datos e intente nuevamente.");
            }

            return new TipoDocumentoResponse
            {
                Code = tipoDocumento.Code,
                Name = tipoDocumento.Name,
                ShortName = tipoDocumento.ShortName,
                SunatCode = tipoDocumento.SunatCode,
                AffectsIgv = tipoDocumento.AffectsIgv,
                IsNonTaxable = tipoDocumento.IsNonTaxable,
                AffectsIncomeTax = tipoDocumento.AffectsIncomeTax,
                AffectsFonavi = tipoDocumento.AffectsFonavi,
                IsService = tipoDocumento.IsService,
                AffectsForeignIgv = tipoDocumento.AffectsForeignIgv,
                AvailableForPurchaseOrder = tipoDocumento.AvailableForPurchaseOrder,
                IsActive = tipoDocumento.IsActive,
                CreatedAt = tipoDocumento.CreatedAt,
                UpdatedAt = tipoDocumento.UpdatedAt,
                RowVersion = tipoDocumento.RowVersion
            };
        }
    }
}
