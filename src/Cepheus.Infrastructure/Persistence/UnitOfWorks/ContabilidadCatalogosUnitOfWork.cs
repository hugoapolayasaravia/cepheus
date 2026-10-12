using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public sealed class ContabilidadCatalogosUnitOfWork
        : IContabilidadCatalogosUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ContabilidadCatalogosUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        

    }
}