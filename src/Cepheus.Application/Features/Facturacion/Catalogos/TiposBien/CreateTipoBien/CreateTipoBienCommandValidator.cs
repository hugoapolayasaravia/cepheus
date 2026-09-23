using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Facturacion.Catalogos.TiposBien.CreateTipoBien
{
    public class CreateTipoBienCommandValidator : AbstractValidator<CreateTipoBienCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoBienCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un registro con ese código.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("La descripción es obligatorio.")
                .MaximumLength(100).WithMessage("La descripción no puede exceder los 100 caracteres.");

            RuleFor(x => x.DetractionRate)
                .InclusiveBetween(0m, 100m).WithMessage("La tasa de detracción debe estar entre 0 y 100.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken ct)
            => !await _uow.Facturacion.Catalogos.TiposBien.Query().AnyAsync(x => x.Code == code.Trim().ToUpper(), ct);
    }
}
