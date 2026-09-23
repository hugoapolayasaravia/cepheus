using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorContratos.UpdateTrabajadorContrato
{
    public class UpdateTrabajadorContratoCommandValidator : AbstractValidator<UpdateTrabajadorContratoCommand>
    {
        public UpdateTrabajadorContratoCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
