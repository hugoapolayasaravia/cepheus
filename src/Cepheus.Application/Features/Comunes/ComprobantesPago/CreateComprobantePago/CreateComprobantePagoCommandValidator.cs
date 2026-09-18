using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.ComprobantesPago.CreateComprobantePago
{
    public class CreateComprobantePagoCommandValidator : AbstractValidator<CreateComprobantePagoCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateComprobantePagoCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del comprobante es obligatorio.")
                .MaximumLength(10).WithMessage("El código no puede exceder los 10 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un comprobante con ese código.");

            RuleFor(x => x.SunatCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código SUNAT es obligatorio.")
                .MaximumLength(2).WithMessage("El código SUNAT no puede exceder los 2 caracteres.")
                .MustAsync(BeUniqueSunatCode).WithMessage("Ya existe un comprobante con ese código SUNAT.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del comprobante es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.ShortName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La abreviatura del comprobante es obligatoria.")
                .MaximumLength(10).WithMessage("La abreviatura no puede exceder los 10 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(255).WithMessage("La descripción no puede exceder los 255 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.Comunes.ComprobantesPago.Query()
                .AnyAsync(c => c.Code == code.Trim().ToUpper(), cancellationToken);

        private async Task<bool> BeUniqueSunatCode(string sunatCode, CancellationToken cancellationToken)
            => !await _uow.Comunes.ComprobantesPago.Query()
                .AnyAsync(c => c.SunatCode == sunatCode.Trim(), cancellationToken);
    }
}
