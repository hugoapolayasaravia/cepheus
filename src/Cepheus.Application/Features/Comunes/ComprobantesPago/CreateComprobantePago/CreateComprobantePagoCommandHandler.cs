using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.ComprobantesPago.Common;
using Cepheus.Domain.Comunes;
using MediatR;

namespace Cepheus.Application.Features.Comunes.ComprobantesPago.CreateComprobantePago
{
    public class CreateComprobantePagoCommandHandler : IRequestHandler<CreateComprobantePagoCommand, ComprobantePagoResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateComprobantePagoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ComprobantePagoResponse> Handle(CreateComprobantePagoCommand request, CancellationToken cancellationToken)
        {
            var comprobante = new ComprobantePago
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                SunatCode = request.SunatCode.Trim(),
                Name = request.Name.Trim(),
                ShortName = request.ShortName.Trim().ToUpperInvariant(),
                Description = string.IsNullOrWhiteSpace(request.Description) ? null : request.Description.Trim(),
                RequiresRuc = request.RequiresRuc,
                RequiresAddress = request.RequiresAddress,
                IsActive = true
            };

            await _uow.ComprobantesPago.AddAsync(comprobante, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(comprobante);
        }

        internal static ComprobantePagoResponse Map(ComprobantePago comprobante) => new()
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
