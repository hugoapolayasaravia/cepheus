using Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesMedida.CreateUnidadMedida
{
    public record CreateUnidadMedidaCommand(
        string Code,
        string Name
    ) : IRequest<UnidadMedidaResponse>;
}