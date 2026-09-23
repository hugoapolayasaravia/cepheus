using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorJornadas.UpdateTrabajadorJornada
{
    public class UpdateTrabajadorJornadaCommandValidator : AbstractValidator<UpdateTrabajadorJornadaCommand>
    {
        public UpdateTrabajadorJornadaCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
