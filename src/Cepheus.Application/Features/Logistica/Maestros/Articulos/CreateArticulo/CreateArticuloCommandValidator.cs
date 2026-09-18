using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Maestros.Articulos.CreateArticulo
{
    public class CreateArticuloCommandValidator : AbstractValidator<CreateArticuloCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateArticuloCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("La descripción del artículo es obligatoria.")
                .MaximumLength(80).WithMessage("La descripción no puede exceder los 80 caracteres.");

            RuleFor(x => x.UnidadMedidaCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La unidad de medida es obligatoria.")
                .MustAsync(UnidadMedidaExists).WithMessage("La unidad de medida indicada no existe.");

            RuleFor(x => x.SubFamiliaCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La subfamilia es obligatoria.")
                .MustAsync(SubFamiliaExists).WithMessage("La subfamilia indicada no existe.");

            RuleFor(x => x.MinStock).GreaterThanOrEqualTo(0).WithMessage("El stock mínimo no puede ser negativo.");
            RuleFor(x => x.MaxStock).GreaterThanOrEqualTo(0).WithMessage("El stock máximo no puede ser negativo.");
            RuleFor(x => x.IncomingStock).GreaterThanOrEqualTo(0).WithMessage("El stock de entrada no puede ser negativo.");
            RuleFor(x => x.LeadTimeDays).GreaterThanOrEqualTo(0).WithMessage("El lead time no puede ser negativo.");

            RuleFor(x => x)
                .Must(x => x.MaxStock >= x.MinStock)
                .WithMessage("El stock máximo no puede ser menor al stock mínimo.")
                .OverridePropertyName(nameof(CreateArticuloCommand.MaxStock));

            RuleFor(x => x.AbcClass)
                .IsInEnum().WithMessage("La clasificación ABC no es válida.");

            RuleFor(x => x.TipoArticuloCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El tipo de artículo es obligatorio.")
                .MustAsync(TipoArticuloExists).WithMessage("El tipo de artículo indicado no existe.");

            RuleFor(x => x.PlanCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El plan es obligatorio.")
                .MustAsync(PlanExists).WithMessage("El plan indicado no existe.");

            RuleFor(x => x.ManufacturerCode)
                .MaximumLength(11).WithMessage("El código de fabricante no puede exceder los 11 caracteres.");

            RuleFor(x => x.PlantOriginCode)
                .MustAsync(PlantaExists).WithMessage("La planta de origen indicada no existe.")
                .When(x => !string.IsNullOrWhiteSpace(x.PlantOriginCode));
        }

        private async Task<bool> UnidadMedidaExists(string code, CancellationToken ct)
            => await _uow.Logistica.Catalogos.UnidadesMedida.Query().AnyAsync(u => u.Code == code.Trim().ToUpper(), ct);

        private async Task<bool> SubFamiliaExists(string code, CancellationToken ct)
            => await _uow.Logistica.Catalogos.SubFamilias.Query().AnyAsync(s => s.Code == code.Trim().ToUpper(), ct);

        private async Task<bool> TipoArticuloExists(string code, CancellationToken ct)
            => await _uow.Logistica.Catalogos.TiposArticulo.Query().AnyAsync(t => t.Code == code.Trim().ToUpper(), ct);

        private async Task<bool> PlanExists(string code, CancellationToken ct)
            => await _uow.Logistica.Catalogos.PlanesArticulo.Query().AnyAsync(p => p.Code == code.Trim().ToUpper(), ct);

        private async Task<bool> PlantaExists(string? code, CancellationToken ct)
            => await _uow.Comunes.Plantas.Query().AnyAsync(p => p.Code == code!.Trim().ToUpper(), ct);
    }
}
