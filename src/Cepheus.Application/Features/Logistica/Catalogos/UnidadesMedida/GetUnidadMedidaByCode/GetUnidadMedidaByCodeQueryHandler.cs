using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.GetUnidadMedidaByCode
{
    public class GetUnidadMedidaByCodeQueryHandler : IRequestHandler<GetUnidadMedidaByCodeQuery, UnidadMedidaResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetUnidadMedidaByCodeQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UnidadMedidaResponse> Handle(GetUnidadMedidaByCodeQuery request, CancellationToken cancellationToken)
        {
            var unidad = await _uow.UnidadesMedida.Query()
                .AsNoTracking()
                .Where(u => u.Code == request.Code)
                .Select(u => new UnidadMedidaResponse
                {
                    Code = u.Code,
                    Name = u.Name,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt,
                    RowVersion = u.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (unidad is null)
            {
                throw new KeyNotFoundException($"Unidad de medida {request.Code} no encontrada.");
            }

            return unidad;
        }
    }
}