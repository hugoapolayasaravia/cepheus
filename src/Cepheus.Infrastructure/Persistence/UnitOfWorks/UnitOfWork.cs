using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Administracion
        private IAdministracionUnitOfWork? _administracion;

        //Comunes
        private IComunesUnitOfWork? _comunes;

        // Logistica
        private ILogisticaUnitOfWork? _logistica;

        // Mantenimiento
        private IMantenimientoUnitOfWork? _mantenimiento;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IAdministracionUnitOfWork Administracion => _administracion ??= new AdministracionUnitOfWork(_context);

        //Comunes
        public IComunesUnitOfWork Comunes => _comunes ??= new ComunesUnitOfWork(_context);


        // Logistica
        public ILogisticaUnitOfWork Logistica => _logistica ??= new LogisticaUnitOfWork(_context);

        // Mantenimiento - Catalogos
        public IMantenimientoUnitOfWork Mantenimiento => _mantenimiento ??= new MantenimientoUnitOfWork(_context);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }





}
