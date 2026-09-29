using Cepheus.API.Endpoints.Facturacion.Transacciones;

namespace Cepheus.API.Extensions.Endpoints;

public static class FacturacionTransaccionesEndpointsExtensions
{
    public static WebApplication MapFacturacionTransaccionesEndpoints(
        this WebApplication app)
    {
        app.MapCotizacionesEndpoints();
        app.MapCotizacionDetallesEndpoints();
        app.MapCotizacionNotasEndpoints();
        app.MapCotizacionMetradoResumenesEndpoints();
        app.MapCotizacionMetradoDetallesEndpoints();


        return app;
    }
}
