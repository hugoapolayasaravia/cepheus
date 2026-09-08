using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.Compradores.CreateComprador
{
    public class CreateCompradorCommandValidator : AbstractValidator<CreateCompradorCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateCompradorCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del comprador es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un comprador con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del comprador es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.Compradores.Query()
                .AnyAsync(c => c.Code == code.Trim().ToUpper(), cancellationToken);
    }
}