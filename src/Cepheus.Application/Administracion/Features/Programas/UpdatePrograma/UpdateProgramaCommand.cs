using Cepheus.Application.Administracion.Features.Programas.Common;
using MediatR;

namespace Cepheus.Application.Administracion.Features.Programas.UpdatePrograma
{
    /// <summary>
    /// SubmoduloId NO se puede editar acá a propósito, mismo criterio que
    /// UpdateSubmodulo (mover de padre es una operación estructural aparte).
    /// </summary>
    public record UpdateProgramaCommand(
        int Id,
        string Code,
        string Name,
        string? Icon,
        string? Tooltip,
        string? Route,
        int DisplayOrder,
        byte[] RowVersion
    ) : IRequest<ProgramaResponse>;


}
