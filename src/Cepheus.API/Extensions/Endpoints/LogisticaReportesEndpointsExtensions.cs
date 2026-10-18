using Cepheus.API.Endpoints.Logistica.Reportes;

namespace Cepheus.API.Extensions.Endpoints;

public static class LogisticaReportesEndpointsExtensions
{
    public static WebApplication MapLogisticaReportesEndpoints(this WebApplication app)
    {
        app.MapReportesLogisticaEndpoints();

        return app;
    }
}
