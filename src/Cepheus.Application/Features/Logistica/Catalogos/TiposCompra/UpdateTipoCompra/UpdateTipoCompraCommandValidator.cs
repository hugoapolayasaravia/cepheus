using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposCompra.UpdateTipoCompra
{
    public class UpdateTipoCompraCommandValidator : AbstractValidator<UpdateTipoCompraCommand>
    {
        public UpdateTipoCompraCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código del tipo de compra es obligatorio.")
                .Length(1).WithMessage("El código debe tener 1 carácter.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del tipo de compra es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}