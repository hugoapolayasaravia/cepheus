using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorFiscals.UpdateTrabajadorFiscal
{
    public class UpdateTrabajadorFiscalCommandValidator : AbstractValidator<UpdateTrabajadorFiscalCommand>
    {
        public UpdateTrabajadorFiscalCommandValidator()
        {
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
