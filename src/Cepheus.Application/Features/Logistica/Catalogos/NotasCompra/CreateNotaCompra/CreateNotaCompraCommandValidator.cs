using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.CreateNotaCompra
{
    public class CreateNotaCompraCommandValidator : AbstractValidator<CreateNotaCompraCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateNotaCompraCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código de la nota es obligatorio.")
                .Length(3).WithMessage("El código debe tener 3 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe una nota con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El texto de la nota es obligatorio.")
                .MaximumLength(200).WithMessage("El texto no puede exceder los 200 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.NotasCompra.Query()
                .AnyAsync(n => n.Code == code.Trim().ToUpper(), cancellationToken);
    }
}