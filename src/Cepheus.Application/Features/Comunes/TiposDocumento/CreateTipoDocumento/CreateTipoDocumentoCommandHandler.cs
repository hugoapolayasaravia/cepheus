using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.TiposDocumento.Common;
using Cepheus.Domain.Comunes;
using MediatR;

namespace Cepheus.Application.Features.Comunes.TiposDocumento.CreateTipoDocumento
{
    public class CreateTipoDocumentoCommandHandler : IRequestHandler<CreateTipoDocumentoCommand, TipoDocumentoResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoDocumentoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoDocumentoResponse> Handle(CreateTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
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
                IsActive = true
            };

            await _uow.TiposDocumento.AddAsync(tipoDocumento, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(tipoDocumento);
        }

        internal static TipoDocumentoResponse Map(TipoDocumento tipoDocumento) => new()
        {
            Id = tipoDocumento.Id,
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
