using System.Data;
using System.Globalization;
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Maestros.ControlCierres.Common;
using Cepheus.Application.Features.Logistica.Transacciones.CierreMensual.Common;
using Cepheus.Application.Features.Logistica.Transacciones.Kardex.Common;
using Cepheus.Application.Features.Logistica.Transacciones.NotaIngresos.Common;
using Cepheus.Domain.Logistica.Enum;
using Cepheus.Domain.Logistica.Maestros;
using Cepheus.Domain.Logistica.Transacciones;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Transacciones.CierreMensual.ProcesarCierreMensual;

/// <summary>
/// Cierre mensual de artículos. Reemplaza los tres SP del legacy (Consumos, Mes_Cierre, AgregaTControl).
///
/// - UNA transacción SERIALIZABLE para toda la planta: si algo falla no queda nada a medias (el legacy tenía el
///   BEGIN TRAN comentado) y nadie puede insertar movimientos en el período mientras se cierra (los rangos
///   leídos quedan bloqueados hasta confirmar). Un bloqueo de aplicación por planta evita dos cierres simultáneos.
/// - Solo cierra el período que sigue al último cerrado y solo si el período ya terminó.
/// - Saldos y costos se calculan en CierreMensualCalculator (mismas reglas que el Kardex).
/// - NO sobrescribe el stock vivo (el legacy pisaba Stock_Plt_Art con el saldo del mes): lo concilia contra
///   saldo + movimientos posteriores y la diferencia queda en ControlCierre.DifferenceAmount e incidencias.
/// - Las incidencias van a CierreIncidencias (por planta y período), no a una tabla global.
/// - Los precios de los documentos de salida se corrigen vía ICierreRevaluador y cada cambio queda auditado.
/// </summary>
public sealed class ProcesarCierreMensualCommandHandler
    : IRequestHandler<ProcesarCierreMensualCommand, CierreMensualResponse>
{
    private const int TimeoutBloqueoMs = 15000;
    private const decimal ToleranciaCantidad = 0.005m;

    private readonly IUnitOfWork _uow;
    private readonly IReadOnlyList<ICierreRevaluador> _revaluadores;

    public ProcesarCierreMensualCommandHandler(IUnitOfWork uow, IEnumerable<ICierreRevaluador> revaluadores)
    {
        _uow = uow;
        _revaluadores = revaluadores.ToList();
    }

    public async Task<CierreMensualResponse> Handle(ProcesarCierreMensualCommand request, CancellationToken ct)
    {
        var planta = request.PlantaCode.Trim().ToUpperInvariant();

        var existe = await _uow.Comunes.Plantas.Query().AsNoTracking().AnyAsync(p => p.Code == planta, ct);
        if (!existe)
            throw new KeyNotFoundException($"La planta {planta} no existe.");

        return await _uow.ExecuteInTransactionAsync(
            token => EjecutarAsync(planta, request.PeriodoCode?.Trim(), token),
            IsolationLevel.Serializable,
            ct);
    }

    private async Task<CierreMensualResponse> EjecutarAsync(string planta, string? periodoSolicitado, CancellationToken ct)
    {
        await _uow.AcquireAppLockAsync($"CierreMensual:{planta}", TimeoutBloqueoMs, ct);

        // ------------------------------------------------------------ 1. qué período se cierra
        var ultimo = await ControlCierreRules.GetLastClosedPeriodAsync(_uow, planta, ct);
        var movimientosDb = _uow.Logistica.Transacciones.MovimientosArticulo.Query().AsNoTracking();

        string periodo;
        if (ultimo is null)
        {
            if (string.IsNullOrWhiteSpace(periodoSolicitado))
                throw new InvalidOperationException(
                    "Es el primer cierre de la planta: indique el período de apertura (AAAAMM).");

            periodo = periodoSolicitado;

            var hayAnteriores = await movimientosDb.AnyAsync(
                m => m.PlantaCode == planta && string.Compare(m.PeriodCode, periodo) < 0, ct);

            if (hayAnteriores)
                throw new InvalidOperationException(
                    $"Hay movimientos en períodos anteriores a {periodo}. El primer cierre debe ser el período del primer movimiento.");
        }
        else
        {
            periodo = ControlCierreRules.NextPeriod(ultimo);

            if (periodoSolicitado is not null && periodoSolicitado != periodo)
                throw new InvalidOperationException(
                    $"El siguiente período a cerrar es {periodo} (último cerrado: {ultimo}).");
        }

        var inicio = DateTime.ParseExact(periodo + "01", "yyyyMMdd", CultureInfo.InvariantCulture);
        var fin = inicio.AddMonths(1).AddDays(-1);

        if (fin >= DateTime.Today)
            throw new InvalidOperationException(
                $"El período {periodo} aún no termina (finaliza el {fin:dd/MM/yyyy}): no se puede cerrar.");

        // ------------------------------------------------------------ 2. datos del período
        var filas = await movimientosDb
            .Where(m => m.PlantaCode == planta && m.PeriodCode == periodo)
            .Select(m => new
            {
                m.Id, m.ArticuloCode, m.FechaMovimiento, m.PeriodCode, m.Tipo, m.Origen, m.Cantidad,
                m.CostoUnitario, m.EsReversion, m.ReversaDeMovimientoId, m.DocumentoCode, m.ItemNumber
            })
            .ToListAsync(ct);

        if (ultimo is null && filas.Count == 0)
            throw new InvalidOperationException(
                $"No hay movimientos en el período {periodo}: verifique el período de apertura.");

        var saldosBase = ultimo is null
            ? new Dictionary<string, (decimal Cantidad, decimal Costo)>()
            : (await _uow.Logistica.Transacciones.SaldosMensualesArticulo.Query().AsNoTracking()
                .Where(s => s.PlantaCode == planta && s.PeriodCode == ultimo)
                .Select(s => new { s.ArticuloCode, s.Quantity, s.AverageCost })
                .ToListAsync(ct))
                .ToDictionary(s => s.ArticuloCode, s => (Cantidad: s.Quantity, Costo: s.AverageCost));

        // Notas de Crédito por ajuste de precio (motivo 01): no mueven stock, solo valorización.
        var notas = await _uow.Logistica.Transacciones.NotaIngresos.Query().AsNoTracking()
            .Where(n =>
                n.PlantaCode == planta &&
                n.ComprobantePagoCode == NotaIngresoRules.ComprobanteNotaCredito &&
                n.MotivoDevolucionCode == NotaIngresoRules.MotivoAjuste &&
                n.Estado == EstadoNotaIngreso.Procesado &&
                n.FechaRecepcion >= inicio && n.FechaRecepcion < inicio.AddMonths(1))
            .Select(n => new
            {
                n.Code, n.FechaRecepcion, n.MonedaCode, n.TipoCambio,
                Lineas = n.Detalles
                    .Where(d => d.Estado == EstadoNotaIngresoDetalle.Procesado)
                    .Select(d => new { d.ArticuloCode, d.Cantidad, d.Precio, d.Descuento })
                    .ToList()
            })
            .ToListAsync(ct);

        var ajustesPorArticulo = notas
            .SelectMany(n => n.Lineas.Select(l =>
            {
                var soles = NotaIngresoRules.ConvertPrices(n.MonedaCode, l.Precio, n.TipoCambio).Soles;
                var neto = Math.Round(soles - (soles * (l.Descuento / 100m)), 6, MidpointRounding.AwayFromZero);
                return (Articulo: l.ArticuloCode, Nota: new AjustePrecioNota(n.Code, n.FechaRecepcion.Date, l.Cantidad, neto));
            }))
            .GroupBy(x => x.Articulo)
            .ToDictionary(g => g.Key, g => (IReadOnlyList<AjustePrecioNota>)g.Select(x => x.Nota).ToList());

        var movimientosPorArticulo = filas
            .GroupBy(f => f.ArticuloCode)
            .ToDictionary(g => g.Key, g => g.ToList());

        var infoPorMovimiento = filas.ToDictionary(f => f.Id);

        // ------------------------------------------------------------ 3. cálculo por artículo
        var articulos = saldosBase.Where(kv => kv.Value.Cantidad != 0).Select(kv => kv.Key)
            .Union(movimientosPorArticulo.Keys)
            .Union(ajustesPorArticulo.Keys)
            .Distinct()
            .OrderBy(a => a, StringComparer.Ordinal)
            .ToList();

        var resultados = new List<CierreArticuloResultado>(articulos.Count);

        foreach (var articulo in articulos)
        {
            saldosBase.TryGetValue(articulo, out var baseSaldo);
            movimientosPorArticulo.TryGetValue(articulo, out var movs);
            ajustesPorArticulo.TryGetValue(articulo, out var ajustes);

            var entradas = new List<KardexEntrada>();
            if (movs is not null)
            {
                entradas.AddRange(movs.Select(f => new KardexEntrada(
                    f.Id, f.FechaMovimiento, f.PeriodCode, f.Tipo, f.Origen,
                    f.Cantidad, f.CostoUnitario, f.EsReversion, f.ReversaDeMovimientoId)));
            }

            resultados.Add(CierreMensualCalculator.Calcular(new CierreArticuloEntrada(
                articulo, baseSaldo.Cantidad, baseSaldo.Costo, entradas,
                ajustes ?? Array.Empty<AjustePrecioNota>())));
        }

        // ------------------------------------------------------------ 4. saldos del período
        var saldosNuevos = new Dictionary<string, decimal>();
        decimal importeTotal = 0;
        var conSaldo = 0;

        foreach (var r in resultados)
        {
            if (!r.TuvoMovimientos && r.Cantidad == 0)
                continue;

            await _uow.Logistica.Transacciones.SaldosMensualesArticulo.AddAsync(new SaldoMensualArticulo
            {
                PlantaCode = planta,
                PeriodCode = periodo,
                ArticuloCode = r.ArticuloCode,
                Quantity = r.Cantidad,
                AverageCost = r.CostoPromedio,
                IncomingQuantity = Math.Round(r.CantidadIngresos, 2, MidpointRounding.AwayFromZero),
                OutgoingQuantity = Math.Round(r.CantidadSalidas, 2, MidpointRounding.AwayFromZero)
            }, ct);

            saldosNuevos[r.ArticuloCode] = r.Cantidad;
            importeTotal += KardexValorizador.Importe(r.Cantidad, r.CostoPromedio);
            conSaldo++;
        }

        // ------------------------------------------------------------ 5. revalorización de documentos de salida
        var porRevaluar = resultados
            .SelectMany(r => r.Salidas.Select(s =>
            {
                var info = infoPorMovimiento[s.MovimientoId];
                return new SalidaValorizada(s.Origen, info.DocumentoCode, info.ItemNumber, r.ArticuloCode, s.Cantidad, s.PrecioNuevo);
            }))
            .ToList();

        var documentosRevalorizados = 0;

        foreach (var revaluador in _revaluadores)
        {
            var propias = porRevaluar.Where(s => revaluador.Origenes.Contains(s.Origen)).ToList();
            if (propias.Count == 0)
                continue;

            var aplicadas = await revaluador.AplicarAsync(planta, periodo, propias, ct);

            foreach (var a in aplicadas)
            {
                await _uow.Logistica.Transacciones.CierreRevaluaciones.AddAsync(new CierreRevaluacion
                {
                    PlantaCode = planta,
                    PeriodCode = periodo,
                    Origen = a.Origen,
                    DocumentoCode = a.DocumentoCode,
                    ItemNumber = a.ItemNumber,
                    ArticuloCode = a.ArticuloCode,
                    Cantidad = a.Cantidad,
                    PrecioAnterior = a.PrecioAnterior,
                    PrecioNuevo = a.PrecioNuevo,
                    TotalAnterior = a.TotalAnterior,
                    TotalNuevo = a.TotalNuevo
                }, ct);
            }

            documentosRevalorizados += aplicadas.Select(a => (a.Origen, a.DocumentoCode)).Distinct().Count();
        }

        // ------------------------------------------------------------ 6. incidencias y conciliación con el stock
        var incidencias = 0;

        foreach (var r in resultados)
        {
            foreach (var i in r.Incidencias)
            {
                await _uow.Logistica.Transacciones.CierreIncidencias.AddAsync(new CierreIncidencia
                {
                    PlantaCode = planta,
                    PeriodCode = periodo,
                    ArticuloCode = r.ArticuloCode,
                    Tipo = i.Tipo,
                    DocumentoCode = i.DocumentoCode,
                    Mensaje = Truncar(i.Mensaje)
                }, ct);
                incidencias++;
            }
        }

        // Stock esperado hoy = saldo del cierre + movimientos de períodos posteriores.
        var posteriores = (await movimientosDb
                .Where(m => m.PlantaCode == planta && string.Compare(m.PeriodCode, periodo) > 0)
                .GroupBy(m => m.ArticuloCode)
                .Select(g => new
                {
                    Articulo = g.Key,
                    Neto = g.Sum(m => m.Tipo == TipoMovimientoArticulo.Ingreso ? m.Cantidad : -m.Cantidad)
                })
                .ToListAsync(ct))
            .ToDictionary(x => x.Articulo, x => x.Neto);

        var stocks = await _uow.Logistica.Maestros.StockArticulos.Query().AsNoTracking()
            .Where(s => s.PlantaCode == planta)
            .Select(s => new { s.ArticuloCode, s.Quantity, Costo = s.AverageCost ?? s.UnitCost })
            .ToListAsync(ct);

        var stockPorArticulo = stocks.ToDictionary(s => s.ArticuloCode);
        decimal diferenciaImporte = 0;

        foreach (var articulo in stockPorArticulo.Keys.Union(saldosNuevos.Keys).Union(posteriores.Keys))
        {
            stockPorArticulo.TryGetValue(articulo, out var stock);
            saldosNuevos.TryGetValue(articulo, out var saldo);
            posteriores.TryGetValue(articulo, out var neto);

            var esperado = saldo + neto;
            var real = stock?.Quantity ?? 0m;
            var diferencia = real - esperado;

            if (Math.Abs(diferencia) < ToleranciaCantidad)
                continue;

            diferenciaImporte += diferencia * (stock?.Costo ?? 0m);

            await _uow.Logistica.Transacciones.CierreIncidencias.AddAsync(new CierreIncidencia
            {
                PlantaCode = planta,
                PeriodCode = periodo,
                ArticuloCode = articulo,
                Tipo = TipoIncidenciaCierre.DiferenciaConStock,
                Mensaje = Truncar(
                    $"El stock actual ({real:0.##}) no coincide con el saldo del Kardex ({esperado:0.##}); diferencia {diferencia:0.##}.")
            }, ct);
            incidencias++;
        }

        // ------------------------------------------------------------ 7. registrar el cierre y confirmar
        var diferenciaTotal = Math.Round(diferenciaImporte, 2, MidpointRounding.AwayFromZero);

        await _uow.Logistica.Maestros.ControlCierres.AddAsync(new ControlCierre
        {
            PlantaCode = planta,
            PeriodCode = periodo,
            ClosureDate = fin,
            DifferenceAmount = diferenciaTotal
        }, ct);

        await _uow.SaveChangesAsync(ct);

        return new CierreMensualResponse(
            planta, periodo, fin,
            conSaldo,
            resultados.Count(r => r.TuvoMovimientos),
            Math.Round(importeTotal, 2, MidpointRounding.AwayFromZero),
            documentosRevalorizados,
            incidencias,
            diferenciaTotal);
    }

    private static string Truncar(string mensaje) => mensaje.Length <= 500 ? mensaje : mensaje[..500];
}
