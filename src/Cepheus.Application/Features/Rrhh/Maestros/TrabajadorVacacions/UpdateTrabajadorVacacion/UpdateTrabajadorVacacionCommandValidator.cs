using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorVacacions.UpdateTrabajadorVacacion
{
    public class UpdateTrabajadorVacacionCommandValidator : AbstractValidator<UpdateTrabajadorVacacionCommand>
    {
        public UpdateTrabajadorVacacionCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
