using Cepheus.Domain.Logistica.Maestros;
using Cepheus.Domain.Logistica.Transacciones;

namespace Cepheus.Application.Features.Logistica.Maestros.StockArticulos.Common;

/// <summary>
/// Punto central para cualquier movimiento de ArticuloStock.
/// - Valida que el período de la fecha del movimiento no esté cerrado.
/// - Modifica el stock (con RowVersion: dos usuarios sobre el mismo artículo no se pisan).
/// - Registra el movimiento en el Kardex (MovimientoArticulo) en la misma unidad de trabajo.
/// No ejecuta SaveChanges: el caso de uso dueño del movimiento confirma todas sus modificaciones
/// en una sola operación EF Core.
/// </summary>
public interface IArticuloStockMovementService
{
    Task<StockMovementResult> ApplyAsync(
        string plantaCode,
        string articuloCode,
        decimal quantity,
        decimal unitCost,
        decimal unitCostUsd,
        decimal discountPercent,
        bool increment,
        bool recalculateAverage,
        StockMovementContext context,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Registra en el Kardex el saldo inicial (Apertura) de un stock recién creado con cantidad.
    /// No modifica ArticuloStock. Devuelve null si la cantidad es cero.
    /// </summary>
    Task<MovimientoArticulo?> RecordOpeningAsync(
        ArticuloStock stock,
        DateTime fecha,
        CancellationToken cancellationToken = default);
}
