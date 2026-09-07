using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.CreateMotivoDevolucion
{
    public class CreateMotivoDevolucionCommandValidator : AbstractValidator<CreateMotivoDevolucionCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateMotivoDevolucionCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del motivo de devolución es obligatorio.")
                .MaximumLength(2).WithMessage("El código no puede exceder los 2 caracteres.")
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un motivo de devolución con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del motivo de devolución es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres.");
        }

        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
            => !await _uow.MotivosDevolucion.Query()
                .AnyAsync(m => m.Code == code.Trim().ToUpper(), cancellationToken);
    }
}
