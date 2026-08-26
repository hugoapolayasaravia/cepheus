using Cepheus.Application.Administracion.Features.Programas.Common;
using Cepheus.Application.Comun.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Administracion.Features.Programas.GetProgramaById
{
    public class GetProgramaByIdQueryHandler : IRequestHandler<GetProgramaByIdQuery, ProgramaResponse>
    {
        private readonly IUnitOfWork _uow;

        public GetProgramaByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ProgramaResponse> Handle(GetProgramaByIdQuery request, CancellationToken cancellationToken)
        {
            var programa = await _uow.Programas.Query()
                .AsNoTracking()
                .Where(p => p.Id == request.Id)
                .Select(p => new ProgramaResponse
                {
                    Id = p.Id,
                    SubmoduloId = p.SubmoduloId,
                    Code = p.Code,
                    Name = p.Name,
                    Icon = p.Icon,
                    Tooltip = p.Tooltip,
                    Route = p.Route,
                    DisplayOrder = p.DisplayOrder,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    RowVersion = p.RowVersion,
                    Permissions = p.Permissions
                        .Select(perm => new PermissionSummary { Id = perm.Id, Code = perm.Code, Name = perm.Name })
                        .ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (programa is null)
            {
                throw new KeyNotFoundException($"Programa {request.Id} no encontrado.");
            }

            return programa;
        }
    }


}
