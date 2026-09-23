using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorSeguros.UpdateTrabajadorSeguro
{
    public class UpdateTrabajadorSeguroCommandValidator : AbstractValidator<UpdateTrabajadorSeguroCommand>
    {
        public UpdateTrabajadorSeguroCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
