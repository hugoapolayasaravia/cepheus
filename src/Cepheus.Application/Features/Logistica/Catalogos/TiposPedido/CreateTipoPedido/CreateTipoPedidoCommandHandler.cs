using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.TiposPedido.Common;
using Cepheus.Domain.Logistica.Catalogos;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposPedido.CreateTipoPedido
{
    public class CreateTipoPedidoCommandHandler : IRequestHandler<CreateTipoPedidoCommand, TipoPedidoResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoPedidoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TipoPedidoResponse> Handle(CreateTipoPedidoCommand request, CancellationToken cancellationToken)
        {
            var tipoPedido = new TipoPedido
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                IsActive = true
            };

            await _uow.TiposPedido.AddAsync(tipoPedido, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(tipoPedido);
        }

        internal static TipoPedidoResponse Map(TipoPedido tipoPedido) => new()
        {
            Code = tipoPedido.Code,
            Name = tipoPedido.Name,
            IsActive = tipoPedido.IsActive,
            CreatedAt = tipoPedido.CreatedAt,
            UpdatedAt = tipoPedido.UpdatedAt,
            RowVersion = tipoPedido.RowVersion
        };
    }
}