using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.Common;
using Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.Common.Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.NotasCompra.CreateNotaCompra
{
    public record CreateNotaCompraCommand(
        string Code,
        string Name
    ) : IRequest<NotaCompraResponse>;
}