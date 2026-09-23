using FluentValidation;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorJornadas.CreateTrabajadorJornada
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
    public class CreateTrabajadorJornadaCommandValidator : AbstractValidator<CreateTrabajadorJornadaCommand>
    {
        public CreateTrabajadorJornadaCommandValidator()
        {
            RuleFor(x => x.TrabajadorCode)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("El trabajador es obligatorio.")
            .Length(5).WithMessage("El código de trabajador debe tener 5 caracteres.");
        }
    }
}
