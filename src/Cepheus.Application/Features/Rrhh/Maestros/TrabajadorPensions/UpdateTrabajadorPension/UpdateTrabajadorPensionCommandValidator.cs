using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorPensions.UpdateTrabajadorPension
{
    public class UpdateTrabajadorPensionCommandValidator : AbstractValidator<UpdateTrabajadorPensionCommand>
    {
        public UpdateTrabajadorPensionCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
