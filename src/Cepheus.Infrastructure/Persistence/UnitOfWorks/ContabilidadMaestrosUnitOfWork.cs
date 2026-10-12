using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public sealed class ContabilidadMaestrosUnitOfWork
        : IContabilidadMaestrosUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ContabilidadMaestrosUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}