using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Facturacion.Catalogos.TiposProducto.Common;
using Cepheus.Domain.Facturacion.Catalogos;
using MediatR;

namespace Cepheus.Application.Features.Facturacion.Catalogos.TiposProducto.CreateTipoProducto
{
    public class CreateTipoProductoCommandHandler : IRequestHandler<CreateTipoProductoCommand, TipoProductoResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoProductoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoProductoResponse> Handle(CreateTipoProductoCommand request, CancellationToken cancellationToken)
        {
            var code = request.Code.Trim().ToUpperInvariant();

            var entity = new TipoProducto
            {
                Code = code,
                Name = request.Name.Trim(),
                IsActive = true
            };

            await _uow.Facturacion.Catalogos.TiposProducto.AddAsync(entity, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(entity);
        }

        internal static TipoProductoResponse Map(TipoProducto e) => new()
        {
            Code = e.Code,
            Name = e.Name,
            IsActive = e.IsActive,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
            RowVersion = e.RowVersion
        };
    }
}
