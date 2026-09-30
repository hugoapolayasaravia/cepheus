using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Domain.Logistica.Maestros;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Maestros.StockArticulos.Common;

/// <summary>
/// Punto central para cualquier movimiento de ArticuloStock.
/// No ejecuta SaveChanges: el caso de uso dueño del movimiento confirma
/// todas sus modificaciones en una sola operación EF Core.
/// </summary>
public interface IArticuloStockMovementService
{
    Task<ArticuloStock> ApplyAsync(
        string plantaCode,
        string articuloCode,
        decimal quantity,
        decimal unitCost,
        decimal unitCostUsd,
        decimal discountPercent,
        bool increment,
        bool recalculateAverage,
        CancellationToken cancellationToken = default);
}
