using Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposArticulo.CreateTipoArticulo
{
    public record CreateTipoArticuloCommand(
        string Name
    ) : IRequest<TipoArticuloResponse>;
}