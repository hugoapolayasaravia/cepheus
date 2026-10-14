using Cepheus.Domain.Contabilidad.Maestros;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

public partial class ApplicationDbContext
{
    // Contabilidad - Maestros
    public DbSet<CuentaContable> CuentasContables => Set<CuentaContable>();
    public DbSet<Anexo> Anexos => Set<Anexo>();
    public DbSet<CuentaBancaria> CuentasBancarias => Set<CuentaBancaria>();


}