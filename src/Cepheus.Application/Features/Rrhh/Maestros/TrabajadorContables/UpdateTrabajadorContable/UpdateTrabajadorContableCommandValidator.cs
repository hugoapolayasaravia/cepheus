using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorContables.UpdateTrabajadorContable
{
    public class UpdateTrabajadorContableCommandValidator : AbstractValidator<UpdateTrabajadorContableCommand>
    {
        public UpdateTrabajadorContableCommandValidator()
        {
            RuleFor(x => x.NumeroItem).InclusiveBetween(1, 10).WithMessage("NumeroItem debe estar entre 1 y 10.");
            RuleFor(x => x.Porcentaje).InclusiveBetween(0, 100).WithMessage("Porcentaje debe estar entre 0 y 100.");
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
