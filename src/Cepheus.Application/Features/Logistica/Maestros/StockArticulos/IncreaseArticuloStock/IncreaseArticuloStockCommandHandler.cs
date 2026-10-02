using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Maestros.StockArticulos.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Maestros.StockArticulos.IncreaseArticuloStock;

public class IncreaseArticuloStockCommandHandler : IRequestHandler<IncreaseArticuloStockCommand, ArticuloStockResponse>
{
    private const int MaxConcurrencyRetries = 3;
    private readonly IUnitOfWork _uow;
    private readonly IArticuloStockMovementService _stock;

    public IncreaseArticuloStockCommandHandler(IUnitOfWork uow, IArticuloStockMovementService stock)
    { _uow = uow; _stock = stock; }

    public async Task<ArticuloStockResponse> Handle(IncreaseArticuloStockCommand request, CancellationToken cancellationToken)
    {
        var plantaCode = request.PlantaCode.Trim().ToUpperInvariant();
        var articuloCode = request.ArticuloCode.Trim().ToUpperInvariant();

        for (var attempt = 1; attempt <= MaxConcurrencyRetries; attempt++)
        {
            var exists = await _uow.Logistica.Maestros.StockArticulos.Query()
                .AnyAsync(s => s.PlantaCode == plantaCode && s.ArticuloCode == articuloCode, cancellationToken);
            if (!exists) throw new KeyNotFoundException($"No hay registro de stock para artículo {articuloCode} en planta {plantaCode}.");

            var stock = await _stock.ApplyAsync(plantaCode, articuloCode, request.Quantity, 0, 0, 0, true, false, cancellationToken);
            try
            {
                await _uow.SaveChangesAsync(cancellationToken);
                return CreateArticuloStock.CreateArticuloStockCommandHandler.Map(stock);
            }
            catch (DbUpdateConcurrencyException) when (attempt < MaxConcurrencyRetries) { }
        }
        throw new InvalidOperationException($"No se pudo actualizar el stock de {articuloCode} en {plantaCode} por alta concurrencia. Intente nuevamente.");
    }
}
