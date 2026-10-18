using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Domain.Contabilidad.Transacciones;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;
using Cepheus.Infrastructure.Persistence.Repositories;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public sealed class ContabilidadTransaccionesUnitOfWork
        : IContabilidadTransaccionesUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ContabilidadTransaccionesUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IRepository<DocumentoCompra>? _documentosCompra;
        public IRepository<DocumentoCompra> DocumentosCompra => _documentosCompra ??= new Repository<DocumentoCompra>(_context);

        private IRepository<DocumentoCompraDetalle>? _documentoCompraDetalles;
        public IRepository<DocumentoCompraDetalle> DocumentoCompraDetalles => _documentoCompraDetalles ??= new Repository<DocumentoCompraDetalle>(_context);

        private IRepository<AsientoContable>? _asientosContables;
        public IRepository<AsientoContable> AsientosContables => _asientosContables ??= new Repository<AsientoContable>(_context);

        private IRepository<AsientoContableDetalle>? _asientoContableDetalles;
        public IRepository<AsientoContableDetalle> AsientoContableDetalles => _asientoContableDetalles ??= new Repository<AsientoContableDetalle>(_context);

    }
}