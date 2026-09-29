using MediatR;

namespace Cepheus.Application.Features.Facturacion.Transacciones.Cotizaciones.CotizacionMetradoDetalles.DeleteCotizacionMetradoDetalle
{
    public record DeleteCotizacionMetradoDetalleCommand(
        string NegocioCode, string Year, string Month, string Code, int LevelNumber,
        string Order, string ProductoTipoCode, string ProductoCode
    ) : IRequest;
}
