using Cepheus.Domain.Logistica.Transacciones;
using Microsoft.EntityFrameworkCore;

namespace Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

public partial class ApplicationDbContext
{
    // Logistica - Transacciones
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<PedidoDetalle> PedidoDetalles => Set<PedidoDetalle>();

    public DbSet<Cotizacion> CotizacionesProveedor => Set<Cotizacion>();
    public DbSet<CotizacionDetalle> CotizacionesDetalleProveedor => Set<CotizacionDetalle>();
    public DbSet<CotizacionPedidoOrigen> CotizacionPedidosOrigen => Set<CotizacionPedidoOrigen>();
    public DbSet<CotizacionProveedor> CotizacionProveedores => Set<CotizacionProveedor>();
    public DbSet<CotizacionProveedorDetalle> CotizacionProveedoresDetalle => Set<CotizacionProveedorDetalle>();

    public DbSet<OrdenCompra> OrdenCompras => Set<OrdenCompra>();
    public DbSet<OrdenCompraDetalle> OrdenComprasDetalle => Set<OrdenCompraDetalle>();
    public DbSet<OrdenCompraPedidoOrigen> OrdenCompraPedidosOrigen => Set<OrdenCompraPedidoOrigen>();

}