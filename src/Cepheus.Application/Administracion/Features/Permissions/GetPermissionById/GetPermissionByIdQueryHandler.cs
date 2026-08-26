using Cepheus.Application.Administracion.Features.Permissions.Common;
using Cepheus.Application.Comun.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Administracion.Features.Permissions.GetPermissionById
{
    public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, PermissionResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetPermissionByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<PermissionResponse> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            var permission = await _uow.Permissions.Query()
                .AsNoTracking()
                .Where(p => p.Id == request.Id)
                .Select(p => new PermissionResponse
                {
                    Id = p.Id,
                    ProgramaId = p.ProgramaId,
                    Code = p.Code,
                    Name = p.Name,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    RowVersion = p.RowVersion
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (permission is null)
            {
                throw new KeyNotFoundException($"Permiso {request.Id} no encontrado.");
            }

            return permission;
        }
    }

}
