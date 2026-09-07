using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Comunes.MotivosDevolucion.Common;
using Cepheus.Domain.Comunes;
using MediatR;

namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.CreateMotivoDevolucion
{
    public class CreateMotivoDevolucionCommandHandler : IRequestHandler<CreateMotivoDevolucionCommand, MotivoDevolucionResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateMotivoDevolucionCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<MotivoDevolucionResponse> Handle(CreateMotivoDevolucionCommand request, CancellationToken cancellationToken)
        {
            var motivo = new MotivoDevolucion
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                AffectsStock = request.AffectsStock,
                IsActive = true
            };

            await _uow.MotivosDevolucion.AddAsync(motivo, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(motivo);
        }

        internal static MotivoDevolucionResponse Map(MotivoDevolucion motivo) => new()
        {
            Id = motivo.Id,
            Code = motivo.Code,
            Name = motivo.Name,
            AffectsStock = motivo.AffectsStock,
            IsActive = motivo.IsActive,
            CreatedAt = motivo.CreatedAt,
            UpdatedAt = motivo.UpdatedAt,
            RowVersion = motivo.RowVersion
        };
    }
}
