using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.TiposCompra.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposCompra.GetTipoCompraByCode
{
    public class GetTipoCompraByCodeQueryHandler : IRequestHandler<GetTipoCompraByCodeQuery, TipoCompraResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetTipoCompraByCodeQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoCompraResponse> Handle(GetTipoCompraByCodeQuery request, CancellationToken cancellationToken)
        {
            var tipoCompra = await _uow.TiposCompra.Query()
                .AsNoTracking()
                .Where(t => t.Code == request.Code)
                .Select(t => new TipoCompraResponse
                {
                    Code = t.Code,
                    Name = t.Name,
                    IsActive = t.IsActive,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    RowVersion = t.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (tipoCompra is null)
            {
                throw new KeyNotFoundException($"Tipo de compra {request.Code} no encontrado.");
            }

            return tipoCompra;
        }
    }
}