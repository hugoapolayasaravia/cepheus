using Cepheus.Application.Administracion.Features.Roles.Common;
using Cepheus.Application.Comun.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Administracion.Features.Roles.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetRoleByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<RoleResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _uow.Roles.Query()
                .AsNoTracking()
                .Where(r => r.Id == request.Id)
                .Select(r => new RoleResponse
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    IsActive = r.IsActive,
                    CreatedAt = r.CreatedAt,
                    UpdatedAt = r.UpdatedAt,
                    RowVersion = r.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (role is null)
            {
                throw new KeyNotFoundException($"Rol {request.Id} no encontrado.");
            }

            return role;
        }
    }

}
