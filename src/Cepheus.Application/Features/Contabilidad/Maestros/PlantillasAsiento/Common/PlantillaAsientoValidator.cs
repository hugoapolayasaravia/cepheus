using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Domain.Contabilidad.Enum;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Contabilidad.Maestros.PlantillasAsiento.Common
{
    public abstract class PlantillaAsientoValidator<T> : AbstractValidator<T>
        where T : IPlantillaAsientoCabecera
    {
        private static readonly ConceptoAsiento[] ConceptosProvision =
        {
            ConceptoAsiento.TotalDocumento, ConceptoAsiento.DetalleDocumento, ConceptoAsiento.Igv,
            ConceptoAsiento.IgvExterior, ConceptoAsiento.Renta, ConceptoAsiento.Fonavi,
            ConceptoAsiento.NoGravable, ConceptoAsiento.Servicio
        };

        private static readonly ConceptoAsiento[] ConceptosTransferencia =
        {
            ConceptoAsiento.MontoNotaIngreso, ConceptoAsiento.NetoNotaIngreso
        };

        protected PlantillaAsientoValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Process)
                .IsInEnum().WithMessage("El proceso no es válido.");

            RuleFor(x => x.TipoAsientoCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El tipo de asiento es obligatorio.")
                .MustAsync(async (c, ct) =>
                    await uow.Contabilidad.Catalogos.TiposAsiento.Query()
                        .AnyAsync(t => t.Code == c.Trim().ToUpper() && t.IsActive, ct))
                .WithMessage("El tipo de asiento no existe o está inactivo.");

            RuleFor(x => x.PurchaseAccountCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La cuenta de compras es obligatoria para la provisión de compras.")
                .MustAsync(async (c, ct) => await AccountExists(uow, c!, ct))
                .WithMessage("La cuenta de compras no existe o está inactiva.")
                .When(x => x.Process == ProcesoAsiento.ProvisionCompraNotaIngreso);

            RuleFor(x => x.PurchaseAccountCode)
                .Must(c => string.IsNullOrWhiteSpace(c))
                .WithMessage("La cuenta de compras solo aplica a la provisión de compras.")
                .When(x => x.Process == ProcesoAsiento.TransferenciaNotaIngreso);

            RuleFor(x => x.Lines)
                .NotEmpty().WithMessage("La plantilla debe tener al menos una línea.");

            RuleFor(x => x.Lines)
                .Custom((lines, context) => ValidateLines(context.InstanceToValidate.Process, lines, context))
                .When(x => x.Lines is { Count: > 0 });

            RuleFor(x => x.Lines)
                .MustAsync(async (lines, ct) =>
                {
                    var codes = lines
                        .Where(l => l.AccountSource == OrigenCuentaAsiento.Fija && !string.IsNullOrWhiteSpace(l.AccountCode))
                        .Select(l => l.AccountCode!.Trim().ToUpper())
                        .Distinct()
                        .ToList();

                    if (codes.Count == 0)
                    {
                        return true;
                    }

                    var found = await uow.Contabilidad.Maestros.CuentasContables.Query()
                        .Where(c => codes.Contains(c.Code) && c.IsActive)
                        .CountAsync(ct);

                    return found == codes.Count;
                })
                .WithMessage("Alguna cuenta fija de las líneas no existe o está inactiva.")
                .When(x => x.Lines is { Count: > 0 });
        }

        private static async Task<bool> AccountExists(IUnitOfWork uow, string code, CancellationToken ct)
            => await uow.Contabilidad.Maestros.CuentasContables.Query()
                .AnyAsync(c => c.Code == code.Trim().ToUpper() && c.IsActive, ct);

        private static void ValidateLines(
            ProcesoAsiento process,
            List<PlantillaAsientoLineaInput> lines,
            ValidationContext<T> context)
        {
            var allowed = process == ProcesoAsiento.ProvisionCompraNotaIngreso
                ? ConceptosProvision
                : ConceptosTransferencia;

            if (lines.Select(l => l.Order).Distinct().Count() != lines.Count)
            {
                context.AddFailure("Lines", "El orden de las líneas no puede repetirse.");
            }

            foreach (var line in lines)
            {
                var label = $"Línea {line.Order}";

                if (line.Order <= 0)
                {
                    context.AddFailure("Lines", $"{label}: el orden debe ser mayor a 0.");
                }

                if (!System.Enum.IsDefined(line.Concept) || !System.Enum.IsDefined(line.Nature)
                    || !System.Enum.IsDefined(line.AccountSource) || !System.Enum.IsDefined(line.AnnexSource)
                    || !System.Enum.IsDefined(line.DescriptionSource) || !System.Enum.IsDefined(line.AccountingType))
                {
                    context.AddFailure("Lines", $"{label}: algún valor de enumeración no es válido.");
                    continue;
                }

                if (!allowed.Contains(line.Concept))
                {
                    context.AddFailure("Lines", $"{label}: el concepto {line.Concept} no aplica al proceso {process}.");
                }

                if (line.AccountSource == OrigenCuentaAsiento.Fija)
                {
                    if (string.IsNullOrWhiteSpace(line.AccountCode))
                    {
                        context.AddFailure("Lines", $"{label}: la cuenta es obligatoria cuando el origen de la cuenta es Fija.");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(line.AccountCode))
                {
                    context.AddFailure("Lines", $"{label}: solo se indica cuenta cuando el origen de la cuenta es Fija.");
                }

                if (line.AccountSource == OrigenCuentaAsiento.LineaDocumento && line.Concept != ConceptoAsiento.DetalleDocumento)
                {
                    context.AddFailure("Lines", $"{label}: la cuenta de la línea del documento solo aplica al concepto DetalleDocumento.");
                }

                if (line.AccountSource == OrigenCuentaAsiento.CuentaPorPagarProveedor && line.Concept != ConceptoAsiento.TotalDocumento)
                {
                    context.AddFailure("Lines", $"{label}: la cuenta por pagar del proveedor solo aplica al concepto TotalDocumento.");
                }

                if (line.Concept == ConceptoAsiento.DetalleDocumento && line.AccountSource == OrigenCuentaAsiento.CuentaPorPagarProveedor)
                {
                    context.AddFailure("Lines", $"{label}: DetalleDocumento no puede usar la cuenta por pagar del proveedor.");
                }

                if (line.AnnexSource == OrigenAnexoAsiento.LineaDocumento && line.Concept != ConceptoAsiento.DetalleDocumento)
                {
                    context.AddFailure("Lines", $"{label}: el anexo de la línea del documento solo aplica al concepto DetalleDocumento.");
                }

                if (line.AnnexSource == OrigenAnexoAsiento.Proveedor && process != ProcesoAsiento.ProvisionCompraNotaIngreso)
                {
                    context.AddFailure("Lines", $"{label}: el anexo del proveedor solo aplica a la provisión de compras.");
                }
            }

            if (!lines.Any(l => l.Nature == NaturalezaAsiento.Debe) || !lines.Any(l => l.Nature == NaturalezaAsiento.Haber))
            {
                context.AddFailure("Lines", "La plantilla debe tener al menos una línea al Debe y una al Haber.");
            }
        }
    }
}
