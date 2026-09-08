using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposCompra.CreateTipoCompra
{
    public class CreateTipoCompraCommandValidator : AbstractValidator<CreateTipoCompraCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateTipoCompraCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del tipo de compra es obligatorio.")
                .Length(1).WithMessage("El código debe tener 1 carácter.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un tipo de compra con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del tipo de compra es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.TiposCompra.Query()
                .AnyAsync(t => t.Code == code.Trim().ToUpper(), cancellationToken);
    }
}