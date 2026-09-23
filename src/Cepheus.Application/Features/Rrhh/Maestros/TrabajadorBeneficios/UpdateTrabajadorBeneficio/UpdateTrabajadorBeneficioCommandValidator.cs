using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorBeneficios.UpdateTrabajadorBeneficio
{
    public class UpdateTrabajadorBeneficioCommandValidator : AbstractValidator<UpdateTrabajadorBeneficioCommand>
    {
        public UpdateTrabajadorBeneficioCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
