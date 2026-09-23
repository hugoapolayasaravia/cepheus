using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorAntecedentes.UpdateTrabajadorAntecedente
{
    public class UpdateTrabajadorAntecedenteCommandValidator : AbstractValidator<UpdateTrabajadorAntecedenteCommand>
    {
        public UpdateTrabajadorAntecedenteCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
