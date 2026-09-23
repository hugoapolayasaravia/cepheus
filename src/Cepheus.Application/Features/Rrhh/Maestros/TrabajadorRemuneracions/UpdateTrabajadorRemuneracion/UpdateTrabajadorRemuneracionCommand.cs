using Cepheus.Application.Features.Rrhh.Maestros.TrabajadorRemuneracions.Common;
using MediatR;

namespace Cepheus.Application.Features.Rrhh.Maestros.TrabajadorRemuneracions.UpdateTrabajadorRemuneracion
{
    public record UpdateTrabajadorRemuneracionCommand(
        long Id,
        decimal SueldoBasico,
        string? MonedaCode,
        string? ModoPagoCode,
        byte[] RowVersion
    ) : IRequest<TrabajadorRemuneracionResponse>;
}
