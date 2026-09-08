using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.SubFamilias.CreateSubFamilia
{
    public class CreateSubFamiliaCommandValidator : AbstractValidator<CreateSubFamiliaCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateSubFamiliaCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código de la subfamilia es obligatorio.")
                .Length(4).WithMessage("El código debe tener 4 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe una subfamilia con ese código.");

            RuleFor(x => x.FamiliaCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La familia es obligatoria.")
                .Length(2).WithMessage("El código de familia debe tener 2 caracteres.")
                .MustAsync(FamiliaExists).WithMessage("La familia indicada no existe.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre de la subfamilia es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.SubFamilias.Query()
                .AnyAsync(s => s.Code == code.Trim().ToUpper(), cancellationToken);

        private async Task<bool> FamiliaExists(string familiaCode, CancellationToken cancellationToken)
            => await _uow.Familias.Query()
                .AnyAsync(f => f.Code == familiaCode.Trim().ToUpper(), cancellationToken);
    }
}