using Cepheus.API.Endpoints.Facturacion.Catalogos;
using Cepheus.API.Endpoints.Facturacion.Maestros;

namespace Cepheus.API.Extensions.Endpoints;

public static class FacturacionMaestrosEndpointsExtensions
{
    public static WebApplication MapFacturacionMaestrosEndpoints(
        this WebApplication app)
    {
        app.MapFacturacionTransportistasEndpoints();
        app.MapFacturacionChoferesEndpoints();
        app.MapFacturacionVehiculosEndpoints();

        app.MapClientesEndpoints();
        app.MapObrasEndpoints();

        app.MapVendedoresEndpoints();
        app.MapCobradoresEndpoints();
        app.MapProductosEndpoints();

        return app;
    }
}
