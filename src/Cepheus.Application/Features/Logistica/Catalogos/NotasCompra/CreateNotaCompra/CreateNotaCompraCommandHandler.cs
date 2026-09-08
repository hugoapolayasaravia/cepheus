using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.Common;
using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.Common.Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.Common;
using Cepheus.Domain.Logistica.Catalogos;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.CreateNotaCompra
{
    public class CreateNotaCompraCommandHandler : IRequestHandler<CreateNotaCompraCommand, NotaCompraResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateNotaCompraCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<NotaCompraResponse> Handle(CreateNotaCompraCommand request, CancellationToken cancellationToken)
        {
            var nota = new NotaCompra
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                IsActive = true
            };

            await _uow.NotasCompra.AddAsync(nota, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(nota);
        }

        internal static NotaCompraResponse Map(NotaCompra nota) => new()
        {
            Code = nota.Code,
            Name = nota.Name,
            IsActive = nota.IsActive,
            CreatedAt = nota.CreatedAt,
            UpdatedAt = nota.UpdatedAt,
            RowVersion = nota.RowVersion
        };
    }
}