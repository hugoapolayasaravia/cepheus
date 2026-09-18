using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Comunes.TiposDocumento.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.TiposDocumento.GetTipoDocumentoById
{
    public class GetTipoDocumentoByIdQueryHandler : IRequestHandler<GetTipoDocumentoByIdQuery, TipoDocumentoResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetTipoDocumentoByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoDocumentoResponse> Handle(GetTipoDocumentoByIdQuery request, CancellationToken cancellationToken)
        {
            var tipoDocumento = await _uow.Comunes.TiposDocumento.Query()
                .AsNoTracking()
                .Where(t => t.Code == request.Code)
                .Select(t => new TipoDocumentoResponse
                {
                    Code = t.Code,
                    Name = t.Name,
                    ShortName = t.ShortName,
                    SunatCode = t.SunatCode,
                    AffectsIgv = t.AffectsIgv,
                    IsNonTaxable = t.IsNonTaxable,
                    AffectsIncomeTax = t.AffectsIncomeTax,
                    AffectsFonavi = t.AffectsFonavi,
                    IsService = t.IsService,
                    AffectsForeignIgv = t.AffectsForeignIgv,
                    AvailableForPurchaseOrder = t.AvailableForPurchaseOrder,
                    IsActive = t.IsActive,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    RowVersion = t.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (tipoDocumento is null)
            {
                throw new KeyNotFoundException($"Tipo de documento {request.Code} no encontrado.");
            }

            return tipoDocumento;
        }
    }
}
