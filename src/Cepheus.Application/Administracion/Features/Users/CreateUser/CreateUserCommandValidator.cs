using Cepheus.Application.Comun.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Administracion.Features.Users.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUnitOfWork _uow;

        public CreateUserCommandValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("El email no tiene un formato válido.")
                .MaximumLength(150)
                .MustAsync(BeUniqueEmail).WithMessage("El email ya está registrado.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100)
                .MustAsync(BeUniqueFullName).WithMessage("Ya existe un usuario registrado con ese nombre y apellido.");
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
            => !await _uow.Users.Query()
                .AnyAsync(u => u.Email == email.Trim().ToLower(), cancellationToken);

        private async Task<bool> BeUniqueFullName(
            CreateUserCommand command, string lastName, CancellationToken cancellationToken)
            => !await _uow.Users.Query()
                .AnyAsync(u =>
                    u.FirstName == command.FirstName.Trim() &&
                    u.LastName == lastName.Trim(),
                    cancellationToken);
    }



}
