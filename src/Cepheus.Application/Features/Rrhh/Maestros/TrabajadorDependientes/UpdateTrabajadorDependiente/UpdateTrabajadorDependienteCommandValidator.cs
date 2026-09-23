using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorDependientes.UpdateTrabajadorDependiente
{
    public class UpdateTrabajadorDependienteCommandValidator : AbstractValidator<UpdateTrabajadorDependienteCommand>
    {
        public UpdateTrabajadorDependienteCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre es obligatorio.");
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
