using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.Compradores.UpdateComprador
{
    public class UpdateCompradorCommandValidator : AbstractValidator<UpdateCompradorCommand>
    {
        public UpdateCompradorCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código del comprador es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del comprador es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}