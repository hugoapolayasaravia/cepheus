using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Maestros.StockArticulos.Common;
using Cepheus.Domain.Logistica.Maestros;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Infrastructure.Services.StockArticulos;

/// <summary>
/// Implementación centralizada del movimiento de stock (único punto que modifica ArticuloStock;
/// lo usan Nota de Ingreso y cualquier proceso futuro).
/// Traduce la regla de Logi_sp_Actualiza_Stock_Planta_Articulo:
/// - entrada con recálculo: promedio ponderado considerando el descuento (en porcentaje);
/// - entrada sin recálculo: solo incrementa la cantidad;
/// - salida: nunca permite stock negativo (el SP no lo valida; lo validaba el PowerBuilder antes);
/// - si no existe registro, una entrada lo crea con Precio promedio = costo unitario.
/// No llama SaveChanges: el caso de uso dueño del movimiento confirma todo en una sola transacción.
///
/// Si el mismo artículo se mueve varias veces dentro de una misma unidad de trabajo y el stock aún no
/// existe en BD, el registro recién creado se reutiliza (no se intenta insertar dos veces).
/// </summary>
public sealed class ArticuloStockMovementService : IArticuloStockMovementService
{
    private readonly IUnitOfWork _uow;

    // Stocks creados en esta unidad de trabajo y todavía sin guardar (el servicio es scoped).
    private readonly Dictionary<(string Planta, string Articulo), ArticuloStock> _pendingNew = new();

    public ArticuloStockMovementService(IUnitOfWork uow) => _uow = uow;

    public async Task<ArticuloStock> ApplyAsync(
        string plantaCode,
        string articuloCode,
        decimal quantity,
        decimal unitCost,
        decimal unitCostUsd,
        decimal discountPercent,
        bool increment,
        bool recalculateAverage,
        CancellationToken cancellationToken = default)
    {
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "La cantidad debe ser mayor que cero.");

        plantaCode = plantaCode.Trim().ToUpperInvariant();
        articuloCode = articuloCode.Trim().ToUpperInvariant();

        if (!_pendingNew.TryGetValue((plantaCode, articuloCode), out var stock))
        {
            stock = await _uow.Logistica.Maestros.StockArticulos.Query()
                .FirstOrDefaultAsync(
                    x => x.PlantaCode == plantaCode && x.ArticuloCode == articuloCode,
                    cancellationToken);
        }

        if (stock is null)
        {
            if (!increment)
                throw new InvalidOperationException(
                    $"No existe stock para {articuloCode} en planta {plantaCode}.");

            stock = new ArticuloStock
            {
                PlantaCode = plantaCode,
                ArticuloCode = articuloCode,
                Quantity = quantity,
                UnitCost = unitCost,
                UnitCostUsd = unitCostUsd,
                AverageCost = unitCost
            };

            await _uow.Logistica.Maestros.StockArticulos.AddAsync(stock, cancellationToken);
            _pendingNew[(plantaCode, articuloCode)] = stock;
            return stock;
        }

        if (!increment)
        {
            if (stock.Quantity < quantity)
            {
                throw new InvalidOperationException(
                    $"Stock insuficiente de {articuloCode} en {plantaCode}. " +
                    $"Disponible: {stock.Quantity}, solicitado: {quantity}.");
            }

            stock.Quantity -= quantity;
            return stock;
        }

        if (!recalculateAverage)
        {
            stock.Quantity += quantity;
            return stock;
        }

        // SP: Precio_Dsto = Costo_Uni - Costo_Uni * (Descuento/100);
        //     Precio_Pro  = (Stock_Actual * Precio_Pro + Stock * Precio_Dsto) / (Stock + Stock_Actual)
        // Las variables del SP son numeric(12,4): se redondea a 4 decimales.
        var currentAverage = stock.AverageCost ?? stock.UnitCost;
        var discountedCost = Math.Round(
            unitCost - (unitCost * (discountPercent / 100m)), 4, MidpointRounding.AwayFromZero);
        var newQuantity = stock.Quantity + quantity;

        stock.AverageCost = newQuantity == 0
            ? discountedCost
            : Math.Round(
                ((stock.Quantity * currentAverage) + (quantity * discountedCost)) / newQuantity,
                4, MidpointRounding.AwayFromZero);

        stock.Quantity = newQuantity;
        stock.UnitCost = unitCost;
        stock.UnitCostUsd = unitCostUsd;

        return stock;
    }
}
