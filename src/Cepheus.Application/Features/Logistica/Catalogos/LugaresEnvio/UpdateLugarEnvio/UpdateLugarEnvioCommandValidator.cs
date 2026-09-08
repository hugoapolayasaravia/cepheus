using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.UpdateLugarEnvio
{
    public class UpdateLugarEnvioCommandValidator : AbstractValidator<UpdateLugarEnvioCommand>
    {
        public UpdateLugarEnvioCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código del lugar de envío es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del lugar de envío es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.Address)
                .MaximumLength(150).WithMessage("La dirección no puede exceder los 150 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}