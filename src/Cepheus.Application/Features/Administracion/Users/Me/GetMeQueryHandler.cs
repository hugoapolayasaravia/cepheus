using Cepheus.Application.Comun.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Administracion.Users.Me
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, MeResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICurrentUserService _currentUserService;

        public GetMeQueryHandler(IUnitOfWork uow, ICurrentUserService currentUserService)
        {
            _uow = uow;
            _currentUserService = currentUserService;
        }

        public async Task<MeResponse> Handle(GetMeQuery request, CancellationToken cancellationToken)
        {
            if (_currentUserService.UserId is null)
            {
                throw new UnauthorizedAccessException("No hay un usuario autenticado.");
            }

            var response = await _uow.Users.Query()
                .AsNoTracking()
                .Where(u => u.Id == _currentUserService.UserId.Value)
                .Select(u => new MeResponse
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Roles = u.UserRoles.Select(ur => ur.Role.Name).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (response is null)
            {
                throw new KeyNotFoundException("Usuario no encontrado.");
            }

            return response;
        }
    }


}
