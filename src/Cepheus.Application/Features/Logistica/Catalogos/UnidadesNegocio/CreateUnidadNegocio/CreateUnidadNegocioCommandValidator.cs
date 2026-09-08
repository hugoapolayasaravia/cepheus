using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesNegocio.CreateUnidadNegocio
{
    public class CreateUnidadNegocioCommandValidator : AbstractValidator<CreateUnidadNegocioCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateUnidadNegocioCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código de la unidad de negocio es obligatorio.")
                .Length(6).WithMessage("El código debe tener 6 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe una unidad de negocio con ese código.");

            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.ParentCode)
                .MustAsync(ParentExists).WithMessage("La unidad de negocio padre indicada no existe.")
                .When(x => !string.IsNullOrWhiteSpace(x.ParentCode));

            RuleFor(x => x)
                .Must(x => !string.Equals(x.Code?.Trim(), x.ParentCode?.Trim(), StringComparison.OrdinalIgnoreCase))
                .WithMessage("Una unidad de negocio no puede ser padre de sí misma.")
                .When(x => !string.IsNullOrWhiteSpace(x.ParentCode));
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.UnidadesNegocio.Query()
                .AnyAsync(u => u.Code == code.Trim().ToUpper(), cancellationToken);

        private async Task<bool> ParentExists(string? parentCode, CancellationToken cancellationToken)
            => await _uow.UnidadesNegocio.Query()
                .AnyAsync(u => u.Code == parentCode!.Trim().ToUpper(), cancellationToken);
    }
}