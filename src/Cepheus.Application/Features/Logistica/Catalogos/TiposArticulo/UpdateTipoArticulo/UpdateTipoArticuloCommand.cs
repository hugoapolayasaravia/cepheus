using Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.UpdateTipoArticulo
{
    public record UpdateTipoArticuloCommand(
        string Code,
        string Name,
        byte[] RowVersion
    ) : IRequest<TipoArticuloResponse>;
}