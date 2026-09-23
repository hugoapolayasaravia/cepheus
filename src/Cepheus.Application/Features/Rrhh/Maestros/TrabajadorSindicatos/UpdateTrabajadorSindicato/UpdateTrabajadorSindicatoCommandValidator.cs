using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSindicatos.UpdateTrabajadorSindicato
{
    public class UpdateTrabajadorSindicatoCommandValidator : AbstractValidator<UpdateTrabajadorSindicatoCommand>
    {
        public UpdateTrabajadorSindicatoCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
