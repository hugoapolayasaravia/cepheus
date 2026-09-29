using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionMetradoResumenes.DeleteCotizacionMetradoResumen
{
    public record DeleteCotizacionMetradoResumenCommand(
        string NegocioCode, string Year, string Month, string Code, int LevelNumber
    ) : IRequest;
}
