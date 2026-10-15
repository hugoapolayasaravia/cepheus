using Cepheus.API.Endpoints.Contabilidad.Transacciones;

namespace Cepheus.API.Extensions.Endpoints;

public static class ContabilidadTransaccionesEndpointsExtensions
{
    public static WebApplication MapContabilidadTransaccionesEndpoints(
        this WebApplication app)
    {
        app.MapDocumentosCompraEndpoints();

        return app;
    }
}
