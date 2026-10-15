using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Contabilidad.Transacciones.DocumentosCompra.Common
{
    /// <summary>
    /// El documento guarda solo la FECHA del tipo de cambio; el valor se consulta en Comunes.TipoCambio.
    /// Soles -> 1. Sin tipo de cambio registrado en esa fecha -> null.
    /// </summary>
    public static class DocumentoCompraTipoCambioResolver
    {
        public static async Task<decimal?> GetVentaAsync(
            IUnitOfWork uow, string monedaCode, DateOnly? fecha, CancellationToken ct)
        {
            if (string.Equals(monedaCode?.Trim(), DocumentoCompraRules.MonedaSoles, StringComparison.OrdinalIgnoreCase))
            {
                return 1m;
            }

            if (fecha is null)
            {
                return null;
            }

            return await uow.Comunes.TiposCambio.Query()
                .AsNoTracking()
                .Where(t => t.Date == fecha.Value)
                .Select(t => (decimal?)t.SellRate)
                .FirstOrDefaultAsync(ct);
        }
    }
}
