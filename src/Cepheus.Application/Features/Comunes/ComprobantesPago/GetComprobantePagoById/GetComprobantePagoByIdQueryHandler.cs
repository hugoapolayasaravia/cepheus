using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.ComprobantesPago.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.ComprobantesPago.GetComprobantePagoById
{
    public class GetComprobantePagoByIdQueryHandler : IRequestHandler<GetComprobantePagoByIdQuery, ComprobantePagoResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetComprobantePagoByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ComprobantePagoResponse> Handle(GetComprobantePagoByIdQuery request, CancellationToken cancellationToken)
        {
            var comprobante = await _uow.ComprobantesPago.Query()
                .AsNoTracking()
                .Where(c => c.Id == request.Id)
                .Select(c => new ComprobantePagoResponse
                {
                    Id = c.Id,
                    Code = c.Code,
                    SunatCode = c.SunatCode,
                    Name = c.Name,
                    ShortName = c.ShortName,
                    Description = c.Description,
                    RequiresRuc = c.RequiresRuc,
                    RequiresAddress = c.RequiresAddress,
                    IsActive = c.IsActive,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                    RowVersion = c.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (comprobante is null)
            {
                throw new KeyNotFoundException($"Comprobante de pago {request.Id} no encontrado.");
            }

            return comprobante;
        }
    }
}
