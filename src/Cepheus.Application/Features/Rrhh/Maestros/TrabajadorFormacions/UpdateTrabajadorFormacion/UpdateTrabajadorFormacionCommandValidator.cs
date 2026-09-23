using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorFormacions.UpdateTrabajadorFormacion
{
    public class UpdateTrabajadorFormacionCommandValidator : AbstractValidator<UpdateTrabajadorFormacionCommand>
    {
        public UpdateTrabajadorFormacionCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
