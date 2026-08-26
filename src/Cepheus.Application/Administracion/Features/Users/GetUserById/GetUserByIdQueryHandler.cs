using Cepheus.Application.Administracion.Features.Users.Common;
using Cepheus.Application.Comun.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Administracion.Features.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetUserByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _uow.Users.Query()
                .AsNoTracking()
                .Where(u => u.Id == request.Id)
                .Select(u => new UserResponse
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt,
                    RowVersion = u.RowVersion,
                    Roles = u.UserRoles.Select(ur => ur.Role.Name).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (user is null)
            {
                throw new KeyNotFoundException($"Usuario {request.Id} no encontrado.");
            }

            return user;
        }
    }




}
