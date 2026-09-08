using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.Tramites.UpdateTramite
{
    public class UpdateTramiteCommandValidator : AbstractValidator<UpdateTramiteCommand>
    {
        public UpdateTramiteCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código del trámite es obligatorio.")
                .Length(1).WithMessage("El código debe tener 1 carácter.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del trámite es obligatorio.")
                .MaximumLength(20).WithMessage("El nombre no puede exceder los 20 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}