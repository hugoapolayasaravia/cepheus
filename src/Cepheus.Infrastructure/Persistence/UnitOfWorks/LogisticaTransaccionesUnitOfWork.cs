// Cepheus.Infrastructure/Persistence/UnitOfWorks/LogisticaTransaccionesUnitOfWork.cs
using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Domain.Logistica.Transacciones;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;
using Cepheus.Infrastructure.Persistence.Repositories;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public sealed class LogisticaTransaccionesUnitOfWork : ILogisticaTransaccionesUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public LogisticaTransaccionesUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IRepository<Pedido>? _pedidos;
        public IRepository<Pedido> Pedidos => _pedidos ??= new Repository<Pedido>(_context);

        private IRepository<PedidoDetalle>? _pedidoDetalles;
        public IRepository<PedidoDetalle> PedidoDetalles => _pedidoDetalles ??= new Repository<PedidoDetalle>(_context);

        private IRepository<Cotizacion>? _cotizaciones;
        public IRepository<Cotizacion> Cotizaciones => _cotizaciones ??= new Repository<Cotizacion>(_context);

        private IRepository<CotizacionDetalle>? _cotizacionDetalles;
        public IRepository<CotizacionDetalle> CotizacionDetalles => _cotizacionDetalles ??= new Repository<CotizacionDetalle>(_context);

        private IRepository<CotizacionPedidoOrigen>? _cotizacionPedidoOrigenes;
        public IRepository<CotizacionPedidoOrigen> CotizacionPedidoOrigenes => _cotizacionPedidoOrigenes ??= new Repository<CotizacionPedidoOrigen>(_context);

        private IRepository<CotizacionProveedor>? _cotizacionProveedores;
        public IRepository<CotizacionProveedor> CotizacionProveedores => _cotizacionProveedores ??= new Repository<CotizacionProveedor>(_context);

        private IRepository<CotizacionProveedorDetalle>? _cotizacionProveedorDetalles;
        public IRepository<CotizacionProveedorDetalle> CotizacionProveedorDetalles => _cotizacionProveedorDetalles ??= new Repository<CotizacionProveedorDetalle>(_context);

        private IRepository<OrdenCompra>? _ordenesCompra;
        public IRepository<OrdenCompra> OrdenesCompra => _ordenesCompra ??= new Repository<OrdenCompra>(_context);

        private IRepository<OrdenCompraDetalle>? _ordenCompraDetalles;
        public IRepository<OrdenCompraDetalle> OrdenCompraDetalles => _ordenCompraDetalles ??= new Repository<OrdenCompraDetalle>(_context);

        private IRepository<OrdenCompraPedidoOrigen>? _ordenCompraPedidoOrigenes;
        public IRepository<OrdenCompraPedidoOrigen> OrdenCompraPedidoOrigenes => _ordenCompraPedidoOrigenes ??= new Repository<OrdenCompraPedidoOrigen>(_context);

        private IRepository<Guia>? _guias;
        public IRepository<Guia> Guias => _guias ??= new Repository<Guia>(_context);

        private IRepository<GuiaDetalle>? _guiaDetalles;
        public IRepository<GuiaDetalle> GuiaDetalles => _guiaDetalles ??= new Repository<GuiaDetalle>(_context);

        private IRepository<NotaIngreso>? _notaIngresos;
        public IRepository<NotaIngreso> NotaIngresos => _notaIngresos ??= new Repository<NotaIngreso>(_context);

        private IRepository<NotaIngresoDetalle>? _notaIngresoDetalles;
        public IRepository<NotaIngresoDetalle> NotaIngresoDetalles => _notaIngresoDetalles ??= new Repository<NotaIngresoDetalle>(_context);

        private IRepository<Importacion>? _importaciones;
        public IRepository<Importacion> Importaciones => _importaciones ??= new Repository<Importacion>(_context);

        private IRepository<ImportacionDetalle>? _importacionDetalles;
        public IRepository<ImportacionDetalle> ImportacionDetalles => _importacionDetalles ??= new Repository<ImportacionDetalle>(_context);

        private IRepository<ImportacionGasto>? _importacionGastos;
        public IRepository<ImportacionGasto> ImportacionGastos => _importacionGastos ??= new Repository<ImportacionGasto>(_context);
    }
}