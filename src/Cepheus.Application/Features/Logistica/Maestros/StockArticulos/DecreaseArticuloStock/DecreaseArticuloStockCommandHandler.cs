using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Maestros.StockArticulos.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Maestros.StockArticulos.DecreaseArticuloStock
{
    public class DecreaseArticuloStockCommandHandler : IRequestHandler<DecreaseArticuloStockCommand, ArticuloStockResponse>
    {
        private const int MaxConcurrencyRetries = 3;

        private readonly IUnitOfWork _uow;

        public DecreaseArticuloStockCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ArticuloStockResponse> Handle(DecreaseArticuloStockCommand request, CancellationToken cancellationToken)
        {
            var plantaCode = request.PlantaCode.Trim().ToUpperInvariant();
            var articuloCode = request.ArticuloCode.Trim().ToUpperInvariant();

            for (var attempt = 1; attempt <= MaxConcurrencyRetries; attempt++)
            {
                var stock = await _uow.Logistica.Maestros.StockArticulos.Query()
                    .FirstOrDefaultAsync(s => s.PlantaCode == plantaCode && s.ArticuloCode == articuloCode, cancellationToken);

                if (stock is null)
                {
                    throw new KeyNotFoundException(
                        $"No hay registro de stock para artículo {articuloCode} en planta {plantaCode}.");
                }

                // Regla dura: nunca permitir stock negativo. Se valida sobre
                // el valor recién leído en cada intento, no sobre un valor
                // cacheado — eso es lo que evita la condición de carrera.
                if (stock.Quantity - request.Quantity < 0)
                {
                    throw new InvalidOperationException(
                        $"Stock insuficiente de {articuloCode} en {plantaCode}. Disponible: {stock.Quantity}, solicitado: {request.Quantity}.");
                }

                stock.Quantity -= request.Quantity;

                try
                {
                    await _uow.SaveChangesAsync(cancellationToken);
                    return CreateArticuloStock.CreateArticuloStockCommandHandler.Map(stock);
                }
                catch (DbUpdateConcurrencyException) when (attempt < MaxConcurrencyRetries)
                {
                    // Otro proceso movió el stock al mismo tiempo: se reintenta
                    // leyendo el valor fresco y volviendo a validar >= 0.
                }
            }

            throw new InvalidOperationException(
                $"No se pudo actualizar el stock de {articuloCode} en {plantaCode} por alta concurrencia. Intente nuevamente.");
        }
    }
}
