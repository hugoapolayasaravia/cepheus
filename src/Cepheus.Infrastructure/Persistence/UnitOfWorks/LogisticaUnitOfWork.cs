using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public sealed class LogisticaUnitOfWork : ILogisticaUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private ILogisticaCatalogosUnitOfWork? _catalogos;
        private ILogisticaMaestrosUnitOfWork? _maestros;

        public LogisticaUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ILogisticaCatalogosUnitOfWork Catalogos =>
            _catalogos ??= new LogisticaCatalogosUnitOfWork(_context);

        public ILogisticaMaestrosUnitOfWork Maestros =>
            _maestros ??= new LogisticaMaestrosUnitOfWork(_context);
    }
}