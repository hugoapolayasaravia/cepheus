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

}