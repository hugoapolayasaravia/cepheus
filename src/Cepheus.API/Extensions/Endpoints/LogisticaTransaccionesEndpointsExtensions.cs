using Cepheus.API.Endpoints.Logistica.Transacciones;

namespace Cepheus.API.Extensions.Endpoints;

public static class LogisticaTransaccionesEndpointsExtensions
{
    public static WebApplication MapLogisticaTransaccionesEndpoints(this WebApplication app)
    {
        app.MapPedidosEndpoints();
        app.MapCotizacionesEndpoints();
        app.MapOrdenesCompraEndpoints();
        app.MapGuiasEndpoints();
        app.MapNotaIngresosEndpoints();
        app.MapImportacionesEndpoints();

        return app;
    }
}