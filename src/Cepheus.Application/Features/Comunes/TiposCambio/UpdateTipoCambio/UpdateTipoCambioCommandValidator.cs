using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.TiposCambio.UpdateTipoCambio
{
    public class UpdateTipoCambioCommandValidator : AbstractValidator<UpdateTipoCambioCommand>
    {
        private readonly IUnitOfWork _uow;

        public UpdateTipoCambioCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Id)
                .GreaterThan(0);

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

        private async Task<bool> BeUniqueDate(UpdateTipoCambioCommand command, DateOnly date, CancellationToken cancellationToken)
            => !await _uow.TiposCambio.Query()
                .AnyAsync(t => t.Date == date && t.Id != command.Id, cancellationToken);
    }
}
