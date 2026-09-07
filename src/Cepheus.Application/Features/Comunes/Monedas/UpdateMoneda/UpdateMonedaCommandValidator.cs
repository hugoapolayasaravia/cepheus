using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.Monedas.UpdateMoneda
{
    public class UpdateMonedaCommandValidator : AbstractValidator<UpdateMonedaCommand>
    {
        private readonly IUnitOfWork _uow;

        public UpdateMonedaCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código de la moneda es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres (ISO 4217).")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe una moneda con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre de la moneda es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.Symbol)
                .MaximumLength(5);

            RuleFor(x => x.NumericCode)
                .Length(3).When(x => !string.IsNullOrWhiteSpace(x.NumericCode))
                .WithMessage("El código numérico ISO 4217 debe tener 3 dígitos.")
                .MustAsync(BeUniqueNumericCode).When(x => !string.IsNullOrWhiteSpace(x.NumericCode))
                .WithMessage("Ya existe una moneda con ese código numérico.");

            RuleFor(x => x.DecimalPlaces)
                .InclusiveBetween(0, 4).WithMessage("Los decimales deben estar entre 0 y 4.");
        }

        private async Task<bool> BeUniqueCode(UpdateMonedaCommand command, string code, CancellationToken cancellationToken)
            => !await _uow.Monedas.Query()
                .AnyAsync(m => m.Code == code.Trim().ToUpper() && m.Id != command.Id, cancellationToken);

        private async Task<bool> BeUniqueNumericCode(UpdateMonedaCommand command, string? numericCode, CancellationToken cancellationToken)
            => !await _uow.Monedas.Query()
                .AnyAsync(m => m.NumericCode == numericCode!.Trim() && m.Id != command.Id, cancellationToken);
    }
}
