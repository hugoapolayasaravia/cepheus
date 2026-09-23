using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorRemuneracions.UpdateTrabajadorRemuneracion
{
    public class UpdateTrabajadorRemuneracionCommandValidator : AbstractValidator<UpdateTrabajadorRemuneracionCommand>
    {
        public UpdateTrabajadorRemuneracionCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
