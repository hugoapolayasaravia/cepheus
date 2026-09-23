using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Facturacion.Catalogos.TiposOperacion.CreateTipoOperacion
{
    public class CreateTipoOperacionCommandValidator : AbstractValidator<CreateTipoOperacionCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoOperacionCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código es obligatorio.")
                .Length(2).WithMessage("El código debe tener 2 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un registro con ese código.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("La descripción es obligatorio.")
                .MaximumLength(255).WithMessage("La descripción no puede exceder los 255 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken ct)
            => !await _uow.Facturacion.Catalogos.TiposOperacion.Query().AnyAsync(x => x.Code == code.Trim().ToUpper(), ct);
    }
}
