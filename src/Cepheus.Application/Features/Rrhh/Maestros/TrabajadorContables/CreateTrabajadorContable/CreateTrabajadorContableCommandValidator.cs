using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorContables.CreateTrabajadorContable
{
    /// <summary>
    /// Validaciones básicas de formato/rango. NO se valida existencia de las
    /// FK a catálogos rrhh (Area, Cargo, Sexo, etc.) porque no conozco los
    /// nombres exactos de sus repositorios en tu IUnitOfWork — agrega
    /// MustAsync(...) por cada una siguiendo el mismo patrón usado en el
    /// resto del sistema (ver CreateEquipoCommandValidator de Mantenimiento
    /// como referencia) una vez que me confirmes esos nombres. La integridad
    /// referencial ya queda protegida a nivel de base de datos por las FK
    /// definidas en el EF Configuration.
    /// </summary>
    public class CreateTrabajadorContableCommandValidator : AbstractValidator<CreateTrabajadorContableCommand>
    {
        public CreateTrabajadorContableCommandValidator()
        {
            RuleFor(x => x.TrabajadorCode)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("El trabajador es obligatorio.")
            .Length(5).WithMessage("El código de trabajador debe tener 5 caracteres.");

            RuleFor(x => x.NumeroItem).InclusiveBetween(1, 10).WithMessage("NumeroItem debe estar entre 1 y 10.");
            RuleFor(x => x.Porcentaje).InclusiveBetween(0, 100).WithMessage("Porcentaje debe estar entre 0 y 100.");
        }
    }
}
