using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Maestros.Transportistas.CreateTransportista
{
    public class CreateTransportistaCommandValidator : AbstractValidator<CreateTransportistaCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateTransportistaCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.DocumentTypeCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El tipo de documento es obligatorio.")
                .MustAsync(DocumentTypeExists).WithMessage("El tipo de documento indicado no existe.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("El número de documento es obligatorio.")
                .MaximumLength(20).WithMessage("El número de documento no puede exceder los 20 caracteres.");

            RuleFor(x => x)
                .MustAsync(BeUniqueDocument)
                .WithMessage("Ya existe un transportista con ese tipo y número de documento.")
                .OverridePropertyName(nameof(CreateTransportistaCommand.DocumentNumber));

            RuleFor(x => x.LegalName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La razón social es obligatoria.")
                .MaximumLength(150).WithMessage("La razón social no puede exceder los 150 caracteres.")
                .MustAsync(BeUniqueLegalName).WithMessage("Ya existe un transportista con esa razón social.");

            RuleFor(x => x.TradeName).MaximumLength(150).WithMessage("El nombre comercial no puede exceder los 150 caracteres.");
            RuleFor(x => x.Address).MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres.");

            RuleFor(x => x.UbigeoCode)
                .MustAsync(UbigeoExists).WithMessage("El ubigeo indicado no existe.")
                .When(x => !string.IsNullOrWhiteSpace(x.UbigeoCode));

            RuleFor(x => x.Phone).MaximumLength(30).WithMessage("El teléfono no puede exceder los 30 caracteres.");
            RuleFor(x => x.Email)
                .MaximumLength(150).WithMessage("El correo no puede exceder los 150 caracteres.")
                .EmailAddress().WithMessage("El correo no tiene un formato válido.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.MtcRegistrationNumber).MaximumLength(30).WithMessage("El registro MTC no puede exceder los 30 caracteres.");
            RuleFor(x => x.Observations).MaximumLength(500).WithMessage("Las observaciones no pueden exceder los 500 caracteres.");
        }

        private async Task<bool> DocumentTypeExists(string code, CancellationToken ct)
            => await _uow.TiposDocumento.Query().AnyAsync(t => t.Code == code.Trim().ToUpper(), ct);

        private async Task<bool> BeUniqueDocument(CreateTransportistaCommand command, CancellationToken ct)
            => !await _uow.Transportistas.Query()
                .AnyAsync(t =>
                    t.DocumentTypeCode == command.DocumentTypeCode.Trim().ToUpper() &&
                    t.DocumentNumber == command.DocumentNumber.Trim(), ct);

        private async Task<bool> BeUniqueLegalName(string name, CancellationToken ct)
            => !await _uow.Transportistas.Query()
                .AnyAsync(t => t.LegalName.ToLower() == name.Trim().ToLower(), ct);

        private async Task<bool> UbigeoExists(string? code, CancellationToken ct)
            => await _uow.Ubigeos.Query().AnyAsync(u => u.Code == code!.Trim().ToUpper(), ct);
    }
}
