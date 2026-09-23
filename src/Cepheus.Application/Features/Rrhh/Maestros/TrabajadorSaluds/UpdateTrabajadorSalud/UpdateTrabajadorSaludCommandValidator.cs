using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSaluds.UpdateTrabajadorSalud
{
    public class UpdateTrabajadorSaludCommandValidator : AbstractValidator<UpdateTrabajadorSaludCommand>
    {
        public UpdateTrabajadorSaludCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
