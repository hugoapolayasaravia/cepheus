using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Catalogos.Tramites.CreateTramite
{
    public class CreateTramiteCommandValidator : AbstractValidator<CreateTramiteCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateTramiteCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del trámite es obligatorio.")
                .Length(1).WithMessage("El código debe tener 1 carácter.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un trámite con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del trámite es obligatorio.")
                .MaximumLength(20).WithMessage("El nombre no puede exceder los 20 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.Tramites.Query()
                .AnyAsync(t => t.Code == code.Trim().ToUpper(), cancellationToken);
    }
}