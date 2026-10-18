using Cepheus.Domain.Contabilidad.Transacciones;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

public partial class ApplicationDbContext
{
    // Contabilidad - Transacciones
    public DbSet<DocumentoCompra> DocumentosCompra => Set<DocumentoCompra>();
    public DbSet<DocumentoCompraDetalle> DocumentoCompraDetalles => Set<DocumentoCompraDetalle>();
    public DbSet<AsientoContable> AsientosContables => Set<AsientoContable>();
    public DbSet<AsientoContableDetalle> AsientoContableDetalles => Set<AsientoContableDetalle>();

}