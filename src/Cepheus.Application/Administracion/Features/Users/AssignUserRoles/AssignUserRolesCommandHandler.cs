using Cepheus.Application.Administracion.Features.Roles.Common;
using Cepheus.Application.Comun.Interfaces;
using Cepheus.Domain.Administracion;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Administracion.Features.Users.AssignUserRoles
{
    public class AssignUserRolesCommandHandler : IRequestHandler<AssignUserRolesCommand, List<RoleResponse>>
    {
        private readonly IUnitOfWork _uow;

        public AssignUserRolesCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<RoleResponse>> Handle(AssignUserRolesCommand request, CancellationToken cancellationToken)
        {
            // Existencia de Usuario y de todos los Roles ya se validó en el Validator.
            var requestedRoleIds = request.RoleIds.Distinct().ToHashSet();

            var currentAssignments = await _uow.RoleUsers.Query()
                .Where(ru => ru.UserId == request.UserId)
                .ToListAsync(cancellationToken);

            var currentRoleIds = currentAssignments.Select(ru => ru.RoleId).ToHashSet();

            var toRemove = currentAssignments
                .Where(ru => !requestedRoleIds.Contains(ru.RoleId))
                .ToList();

            var toAddIds = requestedRoleIds
                .Where(roleId => !currentRoleIds.Contains(roleId))
                .ToList();

            foreach (var assignment in toRemove)
            {
                _uow.RoleUsers.Remove(assignment);
            }

            foreach (var roleId in toAddIds)
            {
                await _uow.RoleUsers.AddAsync(
                    new RoleUser { UserId = request.UserId, RoleId = roleId },
                    cancellationToken);
            }

            await _uow.SaveChangesAsync(cancellationToken);

            return await _uow.RoleUsers.Query()
                .Where(ru => ru.UserId == request.UserId)
                .Select(ru => new RoleResponse
                {
                    Id = ru.Role.Id,
                    Name = ru.Role.Name,
                    Description = ru.Role.Description,
                    IsActive = ru.Role.IsActive,
                    CreatedAt = ru.Role.CreatedAt,
                    UpdatedAt = ru.Role.UpdatedAt,
                    RowVersion = ru.Role.RowVersion
                })
                .OrderBy(r => r.Name)
                .ToListAsync(cancellationToken);
        }
    }

}
