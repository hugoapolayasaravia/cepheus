using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.MotivosDevolucion.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.GetMotivoDevolucionById
{
    public class GetMotivoDevolucionByIdQueryHandler : IRequestHandler<GetMotivoDevolucionByIdQuery, MotivoDevolucionResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetMotivoDevolucionByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<MotivoDevolucionResponse> Handle(GetMotivoDevolucionByIdQuery request, CancellationToken cancellationToken)
        {
            var motivo = await _uow.MotivosDevolucion.Query()
                .AsNoTracking()
                .Where(m => m.Id == request.Id)
                .Select(m => new MotivoDevolucionResponse
                {
                    Id = m.Id,
                    Code = m.Code,
                    Name = m.Name,
                    AffectsStock = m.AffectsStock,
                    IsActive = m.IsActive,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    RowVersion = m.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (motivo is null)
            {
                throw new KeyNotFoundException($"Motivo de devolución {request.Id} no encontrado.");
            }

            return motivo;
        }
    }
}
