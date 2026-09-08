using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposPedido.CreateTipoPedido
{
    public class CreateTipoPedidoCommandValidator : AbstractValidator<CreateTipoPedidoCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoPedidoCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del tipo de pedido es obligatorio.")
                .Length(2).WithMessage("El código debe tener 2 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un tipo de pedido con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del tipo de pedido es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.TiposPedido.Query()
                .AnyAsync(t => t.Code == code.Trim().ToUpper(), cancellationToken);
    }
}