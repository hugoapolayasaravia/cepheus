using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Application.Features.Logistica.Reportes.Common;
using Cepheus.Domain.Logistica.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Application.Features.Logistica.Reportes.ComprasAdm.GetReporteComprasAdm;

/// <summary>Solo lectura y sin SQL dinámico: reemplaza Logi_sp_Rpt_Compras_Adm.</summary>
public sealed class GetReporteComprasAdmQueryHandler : IRequestHandler<GetReporteComprasAdmQuery, ReporteComprasAdmResponse>
{
    private const string PlantaPorDefecto = "OF";

    private readonly IUnitOfWork _uow;

    public GetReporteComprasAdmQueryHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<ReporteComprasAdmResponse> Handle(GetReporteComprasAdmQuery request, CancellationToken ct)
    {
        var planta = ReporteRules.Filtro(request.PlantaCode) ?? PlantaPorDefecto;
        var (desde, hastaExcl) = ReporteRules.Rango(request.FechaDesde, request.FechaHasta);
        var proveedor = ReporteRules.Filtro(request.ProveedorCode);
        var comprobante = ReporteRules.Filtro(request.ComprobanteCode);
        var comprador = ReporteRules.Filtro(request.CompradorCode);

        var q = _uow.Logistica.Transacciones.OrdenServicioDetalles.Query().AsNoTracking()
            .Where(d => d.PlantaCode == planta
                        && d.OrdenServicio.FechaRecepcion >= desde
                        && d.OrdenServicio.FechaRecepcion < hastaExcl);

        if (proveedor is not null) q = q.Where(d => d.OrdenServicio.ProveedorCode == proveedor);
        if (comprobante is not null) q = q.Where(d => d.OrdenServicio.ComprobantePagoCode == comprobante);
        if (comprador is not null) q = q.Where(d => d.OrdenServicio.CompradorCode == comprador);
        if (request.EstadoCode.HasValue)
        {
            var e = (EstadoOrdenServicio)request.EstadoCode.Value;
            q = q.Where(d => d.OrdenServicio.Estado == e);
        }

        var datos = await q.Select(d => new
        {
            o = d.OrdenServicio,
            Comprobante = d.OrdenServicio.ComprobantePago.ShortName,
            ProveedorRuc = d.OrdenServicio.Proveedor.DocumentNumber,
            ProveedorNombre = d.OrdenServicio.Proveedor.LegalName,
            Comprador = d.OrdenServicio.Comprador.Name,
            FormaPago = d.OrdenServicio.FormaPago.Name,
            Dias = d.OrdenServicio.FormaPago.Days,
            d.ItemNumber, d.Glosa,
            d.Articulo.UnidadMedidaCode,
            d.Cantidad, d.Precio, d.Descuento, d.Total
        }).ToListAsync(ct);

        var tipoCambio = await CargarTiposCambioAsync(
            datos.Where(x => ReporteRules.EsDolar(x.o.MonedaCode)).Select(x => x.o.FechaRecepcion.Date).Distinct().ToList(), ct);

        var filas = datos
            .Select(x =>
            {
                var dolar = ReporteRules.EsDolar(x.o.MonedaCode);
                var tc = dolar ? Resolver(tipoCambio, x.o.FechaRecepcion.Date) : 1m;
                var anulada = x.o.Estado == EstadoOrdenServicio.Anulado;
                decimal Monto(decimal v) => anulada ? 0m : ReporteRules.ASoles(v, dolar, tc);

                return new ReporteCompraAdmFilaResponse(
                    x.o.Code, x.Comprobante, x.o.FechaRecepcion, x.o.ProveedorCode, x.ProveedorRuc, x.ProveedorNombre,
                    x.Comprador, x.o.MonedaCode, x.FormaPago, x.Dias, x.o.FechaRecepcion.AddDays(x.Dias),
                    ReporteRules.Descripcion(x.o.Estado),
                    Monto(x.o.Igv), Monto(x.o.Total), Monto(x.o.Monto), Monto(x.o.NoGravable),
                    // Legacy: la Renta no se anula con el estado.
                    ReporteRules.ASoles(x.o.Renta, dolar, tc),
                    x.ItemNumber, x.Glosa, x.UnidadMedidaCode, x.Cantidad,
                    Monto(x.Precio), x.Descuento, Monto(x.Total), x.o.NumeroDocumento);
            })
            .OrderBy(f => f.OrdenServicioCode).ThenBy(f => f.Item)
            .ToList();

        return new ReporteComprasAdmResponse(
            planta, desde, hastaExcl.AddDays(-1), filas.Count, filas.Sum(f => f.Total), filas);
    }

    /// <summary>Tipo de cambio venta por día; si un día no tiene, se usa el último anterior registrado.</summary>
    private async Task<SortedList<DateTime, decimal>> CargarTiposCambioAsync(IReadOnlyList<DateTime> fechas, CancellationToken ct)
    {
        var lista = new SortedList<DateTime, decimal>();
        if (fechas.Count == 0) return lista;

        var min = DateOnly.FromDateTime(fechas.Min().AddDays(-15));
        var max = DateOnly.FromDateTime(fechas.Max());

        var tasas = await _uow.Comunes.TiposCambio.Query().AsNoTracking()
            .Where(t => t.Date >= min && t.Date <= max)
            .Select(t => new { t.Date, t.SellRate })
            .ToListAsync(ct);

        foreach (var t in tasas) lista[t.Date.ToDateTime(TimeOnly.MinValue)] = t.SellRate;
        return lista;
    }

    private static decimal Resolver(SortedList<DateTime, decimal> tasas, DateTime fecha)
    {
        decimal valor = 0m;
        foreach (var kv in tasas)
        {
            if (kv.Key > fecha) break;
            valor = kv.Value;
        }
        return valor;
    }
}
