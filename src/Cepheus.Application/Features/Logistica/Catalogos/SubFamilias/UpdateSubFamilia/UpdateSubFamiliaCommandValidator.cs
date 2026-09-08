using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.SubFamilias.UpdateSubFamilia
{
    public class UpdateSubFamiliaCommandValidator : AbstractValidator<UpdateSubFamiliaCommand>
    {
        public UpdateSubFamiliaCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código de la subfamilia es obligatorio.")
                .Length(4).WithMessage("El código debe tener 4 caracteres.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre de la subfamilia es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}