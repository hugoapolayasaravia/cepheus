using Cepheus.Application.Features.Logistica.Catalogos.Compradores.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.Compradores.CreateComprador
{
    public record CreateCompradorCommand(
        string Code,
        string Name
    ) : IRequest<CompradorResponse>;
}