using Cepheus.API.Endpoints.Logistica.Catalogos;

namespace Cepheus.API.Extensions.Endpoints;

public static class LogisticaCatalogosEndpointsExtensions
{
    public static WebApplication MapLogisticaCatalogosEndpoints(
        this WebApplication app)
    {
        app.MapFamiliasEndpoints();
        app.MapSubFamiliasEndpoints();
        app.MapUnidadesMedidaEndpoints();
        app.MapTiposCompraEndpoints();
        app.MapNotasCompraEndpoints();
        app.MapLugaresEnvioEndpoints();
        app.MapCompradoresEndpoints();
        app.MapTramitesEndpoints();
        app.MapTiposPedidoEndpoints();
        app.MapUnidadesNegocioEndpoints();
        app.MapTiposValeEndpoints();
        app.MapTiposArticuloEndpoints();
        app.MapPlanesArticuloEndpoints();
        app.MapFormasPagoEndpoints();

        return app;
    }
}