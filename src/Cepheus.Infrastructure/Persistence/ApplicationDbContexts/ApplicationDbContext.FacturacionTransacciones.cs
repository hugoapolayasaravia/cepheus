using Cepheus.Domain.Facturacion.Transacciones;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

public partial class ApplicationDbContext
{
    // Facturacion - Transacciones (documento Cotización)

    public DbSet<Cotizacion> Cotizaciones => Set<Cotizacion>();
    public DbSet<CotizacionDetalle> CotizacionesDetalle => Set<CotizacionDetalle>();
    public DbSet<CotizacionNota> CotizacionesNotas => Set<CotizacionNota>();
    public DbSet<CotizacionMetradoResumen> CotizacionesMetradoResumen => Set<CotizacionMetradoResumen>();
    public DbSet<CotizacionMetradoDetalle> CotizacionesMetradoDetalle => Set<CotizacionMetradoDetalle>();

    public DbSet<HojaCorte> HojasCorte => Set<HojaCorte>();
    public DbSet<HojaCorteDetalle> HojasCorteDetalle => Set<HojaCorteDetalle>();

    public DbSet<SolicitudNotaCredito> SolicitudesNotaCredito => Set<SolicitudNotaCredito>();
    public DbSet<SolicitudNotaCreditoDetalle> SolicitudesNotaCreditoDetalle => Set<SolicitudNotaCreditoDetalle>();
    public DbSet<SolicitudNotaCreditoGuia> SolicitudesNotaCreditoGuias => Set<SolicitudNotaCreditoGuia>();
    public DbSet<SolicitudNotaCreditoArchivo> SolicitudesNotaCreditoArchivos => Set<SolicitudNotaCreditoArchivo>();
    public DbSet<SolicitudNotaCreditoAprobacion> SolicitudesNotaCreditoAprobaciones => Set<SolicitudNotaCreditoAprobacion>();

    public DbSet<NotaCreditoVenta> NotasCreditoVenta => Set<NotaCreditoVenta>();
    public DbSet<NotaCreditoVentaDetalle> NotasCreditoVentaDetalle => Set<NotaCreditoVentaDetalle>();
}