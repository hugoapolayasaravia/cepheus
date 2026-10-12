using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

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

    }
}