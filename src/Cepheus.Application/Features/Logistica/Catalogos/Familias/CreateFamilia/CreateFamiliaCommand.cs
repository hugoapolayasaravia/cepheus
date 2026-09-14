using Cepheus.Application.Features.Logistica.Catalogos.Familias.Common;
using MediatR;

namespace Cepheus.Application.Features.Logistica.Catalogos.Familias.CreateFamilia
{
    public record CreateFamiliaCommand(
        string Name
    ) : IRequest<FamiliaResponse>;
}