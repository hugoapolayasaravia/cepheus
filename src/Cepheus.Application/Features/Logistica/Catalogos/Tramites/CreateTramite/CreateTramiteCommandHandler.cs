using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Features.Logistica.Catalogos.Tramites.Common;
using Cepheus.Domain.Logistica.Catalogos;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.Tramites.CreateTramite
{
    public class CreateTramiteCommandHandler : IRequestHandler<CreateTramiteCommand, TramiteResponse>
    {
        private readonly IUnitOfWork _uow;

        public CreateTramiteCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TramiteResponse> Handle(CreateTramiteCommand request, CancellationToken cancellationToken)
        {
            var tramite = new Tramite
            {
                Code = request.Code.Trim().ToUpperInvariant(),
                Name = request.Name.Trim(),
                IsActive = true
            };

            await _uow.Tramites.AddAsync(tramite, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return Map(tramite);
        }

        internal static TramiteResponse Map(Tramite tramite) => new()
        {
            Code = tramite.Code,
            Name = tramite.Name,
            IsActive = tramite.IsActive,
            CreatedAt = tramite.CreatedAt,
            UpdatedAt = tramite.UpdatedAt,
            RowVersion = tramite.RowVersion
        };
    }
}