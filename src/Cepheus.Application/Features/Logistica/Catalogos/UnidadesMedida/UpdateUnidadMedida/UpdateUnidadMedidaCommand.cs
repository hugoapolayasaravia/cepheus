using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.UpdateUnidadMedida
{
    public record UpdateUnidadMedidaCommand(
        string Code,
        string Name,
        byte[] RowVersion
    ) : IRequest<UnidadMedidaResponse>;
}