using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorLaborals.UpdateTrabajadorLaboral
{
    public class UpdateTrabajadorLaboralCommandValidator : AbstractValidator<UpdateTrabajadorLaboralCommand>
    {
        public UpdateTrabajadorLaboralCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
