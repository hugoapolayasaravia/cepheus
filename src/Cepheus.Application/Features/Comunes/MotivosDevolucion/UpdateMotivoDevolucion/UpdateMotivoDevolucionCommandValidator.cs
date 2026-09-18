using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.UpdateMotivoDevolucion
{
    public class UpdateMotivoDevolucionCommandValidator : AbstractValidator<UpdateMotivoDevolucionCommand>
    {
        private readonly IUnitOfWork _uow;

        public UpdateMotivoDevolucionCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del motivo de devolución es obligatorio.")
                .MaximumLength(2)
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un motivo de devolución con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del motivo de devolución es obligatorio.")
                .MaximumLength(50);
        }

        private async Task<bool> BeUniqueCode(UpdateMotivoDevolucionCommand command, string code, CancellationToken cancellationToken)
            => !await _uow.Comunes.MotivosDevolucion.Query()
                .AnyAsync(m => m.Code == code.Trim().ToUpper() && m.Id != command.Id, cancellationToken);
    }
}
