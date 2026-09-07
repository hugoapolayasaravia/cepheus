using Cepheus.Application.Comun.Interfaces;
using MediatR;

namespace Cepheus.Application.Features.Comunes.TiposDocumento.ToggleTipoDocumentoStatus
{
    public class ToggleTipoDocumentoStatusCommandHandler : IRequestHandler<ToggleTipoDocumentoStatusCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ToggleTipoDocumentoStatusCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ToggleTipoDocumentoStatusCommand request, CancellationToken cancellationToken)
        {
            var tipoDocumento = await _uow.TiposDocumento.GetByIdAsync(request.Id, cancellationToken);

            if (tipoDocumento is null)
            {
                throw new KeyNotFoundException($"Tipo de documento {request.Id} no encontrado.");
            }

            tipoDocumento.IsActive = !tipoDocumento.IsActive;

            await _uow.SaveChangesAsync(cancellationToken);

            return tipoDocumento.IsActive;
        }
    }
}
