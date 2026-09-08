using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposPedido.UpdateTipoPedido
{
    public class UpdateTipoPedidoCommandValidator : AbstractValidator<UpdateTipoPedidoCommand>
    {
        public UpdateTipoPedidoCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código del tipo de pedido es obligatorio.")
                .Length(2).WithMessage("El código debe tener 2 caracteres.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del tipo de pedido es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}