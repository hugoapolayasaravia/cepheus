using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.UpdateNotaCompra
{
    public class UpdateNotaCompraCommandValidator : AbstractValidator<UpdateNotaCompraCommand>
    {
        public UpdateNotaCompraCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código de la nota es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El texto de la nota es obligatorio.")
                .MaximumLength(200).WithMessage("El texto no puede exceder los 200 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}