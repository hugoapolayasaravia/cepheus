using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Domain.Facturacion.Transacciones;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;
using Cepheus.Infrastructure.Persistence.Repositories;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public sealed class FacturacionTransaccionesUnitOfWork
        : IFacturacionTransaccionesUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public FacturacionTransaccionesUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IRepository<Cotizacion>? _cotizaciones;
        public IRepository<Cotizacion> Cotizaciones => _cotizaciones ??= new Repository<Cotizacion>(_context);

        private IRepository<CotizacionDetalle>? _cotizacionesDetalle;
        public IRepository<CotizacionDetalle> CotizacionesDetalle => _cotizacionesDetalle ??= new Repository<CotizacionDetalle>(_context);

        private IRepository<CotizacionNota>? _cotizacionesNotas;
        public IRepository<CotizacionNota> CotizacionesNotas => _cotizacionesNotas ??= new Repository<CotizacionNota>(_context);

        private IRepository<CotizacionMetradoResumen>? _cotizacionesMetradoResumen;
        public IRepository<CotizacionMetradoResumen> CotizacionesMetradoResumen => _cotizacionesMetradoResumen ??= new Repository<CotizacionMetradoResumen>(_context);

        private IRepository<CotizacionMetradoDetalle>? _cotizacionesMetradoDetalle;
        public IRepository<CotizacionMetradoDetalle> CotizacionesMetradoDetalle => _cotizacionesMetradoDetalle ??= new Repository<CotizacionMetradoDetalle>(_context);

        private IRepository<HojaCorte>? _hojasCorte;
        public IRepository<HojaCorte> HojasCorte => _hojasCorte ??= new Repository<HojaCorte>(_context);

        private IRepository<HojaCorteDetalle>? _hojasCorteDetalle;
        public IRepository<HojaCorteDetalle> HojasCorteDetalle => _hojasCorteDetalle ??= new Repository<HojaCorteDetalle>(_context);

        private IRepository<SolicitudNotaCredito>? _solicitudesNotaCredito;
        public IRepository<SolicitudNotaCredito> SolicitudesNotaCredito => _solicitudesNotaCredito ??= new Repository<SolicitudNotaCredito>(_context);

        private IRepository<SolicitudNotaCreditoDetalle>? _solicitudesNotaCreditoDetalle;
        public IRepository<SolicitudNotaCreditoDetalle> SolicitudesNotaCreditoDetalle => _solicitudesNotaCreditoDetalle ??= new Repository<SolicitudNotaCreditoDetalle>(_context);

        private IRepository<SolicitudNotaCreditoGuia>? _solicitudesNotaCreditoGuias;
        public IRepository<SolicitudNotaCreditoGuia> SolicitudesNotaCreditoGuias => _solicitudesNotaCreditoGuias ??= new Repository<SolicitudNotaCreditoGuia>(_context);

        private IRepository<SolicitudNotaCreditoArchivo>? _solicitudesNotaCreditoArchivos;
        public IRepository<SolicitudNotaCreditoArchivo> SolicitudesNotaCreditoArchivos => _solicitudesNotaCreditoArchivos ??= new Repository<SolicitudNotaCreditoArchivo>(_context);

        private IRepository<SolicitudNotaCreditoAprobacion>? _solicitudesNotaCreditoAprobaciones;
        public IRepository<SolicitudNotaCreditoAprobacion> SolicitudesNotaCreditoAprobaciones => _solicitudesNotaCreditoAprobaciones ??= new Repository<SolicitudNotaCreditoAprobacion>(_context);

        private IRepository<NotaCreditoVenta>? _notasCreditoVenta;
        public IRepository<NotaCreditoVenta> NotasCreditoVenta => _notasCreditoVenta ??= new Repository<NotaCreditoVenta>(_context);

        private IRepository<NotaCreditoVentaDetalle>? _notasCreditoVentaDetalle;
        public IRepository<NotaCreditoVentaDetalle> NotasCreditoVentaDetalle => _notasCreditoVentaDetalle ??= new Repository<NotaCreditoVentaDetalle>(_context);
    }
}