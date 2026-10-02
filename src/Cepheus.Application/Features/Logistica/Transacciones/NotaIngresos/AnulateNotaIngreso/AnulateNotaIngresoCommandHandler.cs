using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Maestros.StockArticulos.Common;
using Cepheus.Application.Features.Logistica.Transacciones.NotaIngresos.Common;
using Cepheus.Domain.Logistica.Enum;
using Cepheus.Domain.Logistica.Transacciones;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Transacciones.NotaIngresos.AnulateNotaIngreso;

/// <summary>
/// Un solo SaveChanges: nota, líneas, stock y OC quedan anulados/revertidos juntos o ninguno.
/// </summary>
public sealed class AnulateNotaIngresoCommandHandler
    : IRequestHandler<AnulateNotaIngresoCommand, NotaIngresoResponse>
{
    private readonly IUnitOfWork _uow;
    private readonly IArticuloStockMovementService _stock;

    public AnulateNotaIngresoCommandHandler(IUnitOfWork uow, IArticuloStockMovementService stock)
    {
        _uow = uow;
        _stock = stock;
    }

    public async Task<NotaIngresoResponse> Handle(AnulateNotaIngresoCommand request, CancellationToken ct)
    {
        var planta = NotaIngresoRules.Normalize(request.PlantaCode);
        var code = NotaIngresoRules.Normalize(request.Code);

        var note = await _uow.Logistica.Transacciones.NotaIngresos.Query()
            .Include(x => x.Detalles)
            .Include(x => x.ComprobantePago)
            .Include(x => x.MotivoDevolucion)
            .FirstOrDefaultAsync(x => x.PlantaCode == planta && x.Code == code, ct)
            ?? throw new KeyNotFoundException($"La Nota de Ingreso {planta}/{code} no existe.");

        if (note.Estado == EstadoNotaIngreso.Anulado)
            throw new InvalidOperationException("La Nota de Ingreso ya está anulada.");

        if (!string.IsNullOrWhiteSpace(note.AsientoContable))
            throw new InvalidOperationException(
                "La Nota de Ingreso tiene asiento contable. Imposible su anulación.");

        if (!string.IsNullOrWhiteSpace(note.CodigoVale))
            throw new InvalidOperationException(
                "La Nota de Ingreso tiene un Vale de Salida asociado. Imposible su anulación.");

        if (note.Condicion != CondicionNotaIngreso.OrdenCompra)
            throw new InvalidOperationException("La anulación de notas con guías anexadas aún no está disponible.");
        if (note.Origen != OrigenNotaIngreso.Compra)
            throw new InvalidOperationException(
                "La anulación de notas de importación o transferencia aún no está disponible.");

        await NotaIngresoRules.EnsurePeriodOpenAsync(
            _uow, planta, note.FechaRecepcion,
            "La Nota de Ingreso está procesada y su período está cerrado. Imposible su anulación.", ct);

        var lineas = note.Detalles.Where(d => d.Estado == EstadoNotaIngresoDetalle.Procesado).ToList();

        if (note.ComprobantePago.Code == NotaIngresoRules.ComprobanteNotaCredito)
            await AnularNotaCreditoAsync(note, lineas, planta, ct);
        else
            await AnularRecepcionAsync(note, lineas, planta, ct);

        foreach (var linea in lineas)
            linea.Estado = EstadoNotaIngresoDetalle.Anulado;
        note.Estado = EstadoNotaIngreso.Anulado;

        await _uow.SaveChangesAsync(ct);

        return await NotaIngresoReader.GetAsync(_uow, planta, code, ct);
    }

    /// <summary>
    /// Nota de Crédito: solo la devolución (motivo 02) descontó stock al registrarse, así que solo ella
    /// lo repone. El ajuste (motivo 01) no toca stock. No afecta a la OC.
    /// </summary>
    private async Task AnularNotaCreditoAsync(
        NotaIngreso note,
        List<NotaIngresoDetalle> lineas,
        string planta,
        CancellationToken ct)
    {
        if (note.MotivoDevolucion?.Code != NotaIngresoRules.MotivoDevolucion)
            return;

        foreach (var linea in lineas)
        {
            await _stock.ApplyAsync(
                planta, linea.ArticuloCode, linea.Cantidad, 0m, 0m, 0m,
                increment: true, recalculateAverage: false, ct);
        }
    }

    /// <summary>
    /// Recepción contra OC: resta el stock ingresado (sin permitir stock negativo, lo valida el servicio
    /// central), revierte lo entregado en la OC por línea y pedido, y recalcula el estado de la OC.
    /// </summary>
    private async Task AnularRecepcionAsync(
        NotaIngreso note,
        List<NotaIngresoDetalle> lineas,
        string planta,
        CancellationToken ct)
    {
        var ocCode = note.OrdenCompraCode
            ?? throw new InvalidOperationException("La Nota de Ingreso no tiene Orden de Compra asociada.");

        var oc = await _uow.Logistica.Transacciones.OrdenesCompra.Query()
            .Include(x => x.Detalles)
                .ThenInclude(d => d.Origenes)
            .FirstOrDefaultAsync(x => x.PlantaCode == planta && x.Code == ocCode, ct)
            ?? throw new KeyNotFoundException($"La Orden de Compra {ocCode} no existe en la planta {planta}.");

        foreach (var linea in lineas)
        {
            // Si el stock no alcanza (ya se consumió), el servicio lanza InvalidOperationException (409).
            await _stock.ApplyAsync(
                planta, linea.ArticuloCode, linea.Cantidad, 0m, 0m, 0m,
                increment: false, recalculateAverage: false, ct);

            var ocDetalle = oc.Detalles.FirstOrDefault(d => d.ArticuloCode == linea.ArticuloCode);
            if (ocDetalle is not null)
                NotaIngresoOrdenCompraUpdater.RevertDelivery(ocDetalle, linea.PedidoCode, linea.Cantidad);
        }

        NotaIngresoOrdenCompraUpdater.RecalculateEstado(oc);
    }
}
