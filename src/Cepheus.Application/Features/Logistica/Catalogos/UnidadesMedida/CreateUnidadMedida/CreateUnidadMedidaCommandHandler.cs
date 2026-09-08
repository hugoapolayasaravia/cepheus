using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.Common;
using Cepheus.Domain.Logistica.Catalogos;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.CreateUnidadMedida
{
    public class CreateUnidadMedidaCommandHandler : IRequestHandler<CreateUnidadMedidaCommand, UnidadMedidaResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateUnidadMedidaCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UnidadMedidaResponse> Handle(CreateUnidadMedidaCommand request, CancellationToken cancellationToken)
        {
            var unidad = new UnidadMedida
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                IsActive = true
            };

            await _uow.UnidadesMedida.AddAsync(unidad, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(unidad);
        }

        internal static UnidadMedidaResponse Map(UnidadMedida unidad) => new()
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