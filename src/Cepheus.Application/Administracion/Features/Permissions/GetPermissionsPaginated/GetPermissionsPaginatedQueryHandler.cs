using Cepheus.Application.Administracion.Features.Permissions.Common;
using Cepheus.Application.Comun.Extensions;
using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Comun.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Administracion.Features.Permissions.GetPermissionsPaginated
{
    public class GetPermissionsPaginatedQueryHandler
    : IRequestHandler<GetPermissionsPaginatedQuery, PagedResult<PermissionResponse>>
    {
        private readonly IUnitOfWork _uow;

        public GetPermissionsPaginatedQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<PagedResult<PermissionResponse>> Handle(
            GetPermissionsPaginatedQuery request, CancellationToken cancellationToken)
        {
            var query = _uow.Permissions.Query().AsNoTracking();

            if (request.ProgramaId.HasValue)
            {
                query = query.Where(p => p.ProgramaId == request.ProgramaId.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim().ToLower();
                query = query.Where(p =>
                    p.Code.ToLower().Contains(search) ||
                    p.Name.ToLower().Contains(search));
            }

            if (request.IsActive.HasValue)
            {
                query = query.Where(p => p.IsActive == request.IsActive.Value);
            }

            var sortDesc = request.SortDesc ?? false;
            var pageNumber = request.PageNumber ?? 1;
            var pageSize = request.PageSize ?? 10;

            var sortedQuery = string.IsNullOrWhiteSpace(request.SortBy)
                ? query.OrderBy(p => p.Code)
                : query.ApplySort(request.SortBy, sortDesc);

            var projected = sortedQuery.Select(p => new PermissionResponse
            {
                Id = p.Id,
                ProgramaId = p.ProgramaId,
                Code = p.Code,
                Name = p.Name,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                RowVersion = p.RowVersion
            });

            return await projected.ToPagedResultAsync(pageNumber, pageSize, cancellationToken);
        }
    }

}
