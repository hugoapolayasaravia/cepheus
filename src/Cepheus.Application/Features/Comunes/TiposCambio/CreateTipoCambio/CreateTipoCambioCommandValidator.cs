using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.TiposCambio.CreateTipoCambio
{
    public class CreateTipoCambioCommandValidator : AbstractValidator<CreateTipoCambioCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoCambioCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Date)
                .Cascade(CascadeMode.Stop)
                .NotEqual(default(DateOnly)).WithMessage("La fecha es obligatoria.")
                .MustAsync(BeUniqueDate).WithMessage("Ya existe un tipo de cambio registrado para esa fecha.");

            RuleFor(x => x.SellRate)
                .GreaterThan(0).WithMessage("El tipo de cambio venta debe ser mayor a 0.");

            RuleFor(x => x.BuyRate)
                .GreaterThan(0).WithMessage("El tipo de cambio compra debe ser mayor a 0.");

            RuleFor(x => x)
                .Must(x => x.BuyRate <= x.SellRate)
                .WithMessage("El tipo de cambio compra no puede ser mayor al de venta.")
                .OverridePropertyName("BuyRate");
        }

        private async Task<bool> BeUniqueDate(DateOnly date, CancellationToken cancellationToken)
            => !await _uow.Comunes.TiposCambio.Query()
                .AnyAsync(t => t.Date == date, cancellationToken);
    }
}
