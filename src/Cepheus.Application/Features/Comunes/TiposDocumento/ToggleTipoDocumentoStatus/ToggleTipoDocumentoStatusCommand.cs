using MediatR;

namespace Cepheus.Application.Features.Comunes.TiposDocumento.ToggleTipoDocumentoStatus
{
    public record ToggleTipoDocumentoStatusCommand(int Id) : IRequest<bool>;
}
