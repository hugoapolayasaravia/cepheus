using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.Familias.UpdateFamilia
{
    public class UpdateFamiliaCommandValidator : AbstractValidator<UpdateFamiliaCommand>
    {
        public UpdateFamiliaCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código de la familia es obligatorio.")
                .Length(2).WithMessage("El código debe tener 2 caracteres.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre de la familia es obligatorio.")
                .MaximumLength(60).WithMessage("El nombre no puede exceder los 60 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}