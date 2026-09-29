using Cepheus.API.Endpoints.Logistica.Transacciones;

namespace Cepheus.API.Extensions.Endpoints;

public static class LogisticaTransaccionesEndpointsExtensions
{
    public static WebApplication MapLogisticaTransaccionesEndpoints(this WebApplication app)
    {
        app.MapPedidosEndpoints();
        app.MapCotizacionesEndpoints();
        app.MapOrdenesCompraEndpoints();

        return app;
    }
}