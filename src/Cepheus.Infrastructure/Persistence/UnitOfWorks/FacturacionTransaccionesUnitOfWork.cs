using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

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


    }
}