using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.CreateUnidadMedida
{
    public class CreateUnidadMedidaCommandValidator : AbstractValidator<CreateUnidadMedidaCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateUnidadMedidaCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código de la unidad de medida es obligatorio.")
                .Length(2).WithMessage("El código debe tener 2 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe una unidad de medida con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre de la unidad de medida es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.UnidadesMedida.Query()
                .AnyAsync(u => u.Code == code.Trim().ToUpper(), cancellationToken);
    }
}