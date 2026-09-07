using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Comunes.TiposDocumento.UpdateTipoDocumento
{
    public class UpdateTipoDocumentoCommandValidator : AbstractValidator<UpdateTipoDocumentoCommand>
    {
        private readonly IUnitOfWork _uow;

        public UpdateTipoDocumentoCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El código del tipo de documento es obligatorio.")
                .MaximumLength(2)
                .MustAsync(BeUniqueCode).WithMessage("Ya existe un tipo de documento con ese código.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre del tipo de documento es obligatorio.")
                .MaximumLength(50);

            RuleFor(x => x.ShortName)
                .MaximumLength(3);

            RuleFor(x => x.SunatCode)
                .MaximumLength(2);
        }

        private async Task<bool> BeUniqueCode(UpdateTipoDocumentoCommand command, string code, CancellationToken cancellationToken)
            => !await _uow.TiposDocumento.Query()
                .AnyAsync(t => t.Code == code.Trim().ToUpper() && t.Id != command.Id, cancellationToken);
    }
}
