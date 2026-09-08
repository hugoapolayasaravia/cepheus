using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.LugaresEnvio.CreateLugarEnvio
{
    public class CreateLugarEnvioCommandValidator : AbstractValidator<CreateLugarEnvioCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateLugarEnvioCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del lugar de envío es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un lugar de envío con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del lugar de envío es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");

            RuleFor(x => x.Address)
                .MaximumLength(150).WithMessage("La dirección no puede exceder los 150 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.LugaresEnvio.Query()
                .AnyAsync(l => l.Code == code.Trim().ToUpper(), cancellationToken);
    }
}