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

    }
}