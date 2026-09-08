using Cepheus.Application.Features.Logistica.Catalogos.TiposCompra.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.TiposCompra.CreateTipoCompra
{
    public record CreateTipoCompraCommand(
        string Code,
        string Name
    ) : IRequest<TipoCompraResponse>;
}