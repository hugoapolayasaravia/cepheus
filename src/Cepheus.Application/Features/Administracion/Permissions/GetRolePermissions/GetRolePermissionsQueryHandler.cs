using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Administracion.Permissions.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Administracion.Permissions.GetRolePermissions
{
    public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, List<PermissionResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetRolePermissionsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<PermissionResponse>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            var roleExists = await _uow.Roles.Query()
                .AnyAsync(r => r.Id == request.RoleId, cancellationToken);

            if (!roleExists)
            {
                throw new KeyNotFoundException($"Rol {request.RoleId} no encontrado.");
            }

            return await _uow.PermissionRoles.Query()
                .Where(pr => pr.RoleId == request.RoleId)
                .Select(pr => new PermissionResponse
                {
                    Id = pr.Permission.Id,
                    ProgramaId = pr.Permission.ProgramaId,
                    Code = pr.Permission.Code,
                    Name = pr.Permission.Name,
                    IsActive = pr.Permission.IsActive,
                    CreatedAt = pr.Permission.CreatedAt,
                    UpdatedAt = pr.Permission.UpdatedAt,
                    RowVersion = pr.Permission.RowVersion
                })
                .OrderBy(p => p.Code)
                .ToListAsync(cancellationToken);
        }
    }

}
