using Cepheus.Application.Comun.Interfaces;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Users.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ICurrentUserService _currentUserService;

        public ChangePasswordCommandHandler(
            IUnitOfWork uow,
            IPasswordHasher passwordHasher,
            ICurrentUserService currentUserService)
        {
            _uow = uow;
            _passwordHasher = passwordHasher;
            _currentUserService = currentUserService;
        }

        public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != _currentUserService.UserId)
            {
                throw new UnauthorizedAccessException("No puede cambiar la contraseña de otro usuario.");
            }

            var user = await _uow.Users.GetByIdAsync(request.Id, cancellationToken);

            if (user is null)
            {
                throw new KeyNotFoundException($"Usuario {request.Id} no encontrado.");
            }

            if (!_passwordHasher.Verify(request.CurrentPassword, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("La contraseña actual no es correcta.");
            }

            // Entidad ya trackeada (GetByIdAsync -> FindAsync); no hace falta llamar Update().
            user.PasswordHash = _passwordHasher.Hash(request.NewPassword);

            await _uow.SaveChangesAsync(cancellationToken);
        }
    }

}
