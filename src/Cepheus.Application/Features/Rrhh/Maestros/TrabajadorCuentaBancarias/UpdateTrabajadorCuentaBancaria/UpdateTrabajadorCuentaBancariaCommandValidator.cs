using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorCuentaBancarias.UpdateTrabajadorCuentaBancaria
{
    public class UpdateTrabajadorCuentaBancariaCommandValidator : AbstractValidator<UpdateTrabajadorCuentaBancariaCommand>
    {
        public UpdateTrabajadorCuentaBancariaCommandValidator()
        {
            RuleFor(x => x.TipoOperacion).NotEmpty().WithMessage("TipoOperacion es obligatorio.");
            RuleFor(x => x.RowVersion).NotEmpty().WithMessage("RowVersion es obligatorio para control de concurrencia.");
        }
    }
}
