using FluentValidation;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.UpdateUnidadMedida
{
    public class UpdateUnidadMedidaCommandValidator : AbstractValidator<UpdateUnidadMedidaCommand>
    {
        public UpdateUnidadMedidaCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código de la unidad de medida es obligatorio.")
                .Length(2).WithMessage("El código debe tener 2 caracteres.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre de la unidad de medida es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}