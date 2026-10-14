using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Domain.Contabilidad.Maestros;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;
using Cepheus.Infrastructure.Persistence.Repositories;

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

        private IRepository<CuentaContable>? _cuentasContables;
        public IRepository<CuentaContable> CuentasContables => _cuentasContables ??= new Repository<CuentaContable>(_context);

        private IRepository<Anexo>? _anexos;
        public IRepository<Anexo> Anexos => _anexos ??= new Repository<Anexo>(_context);

        private IRepository<CuentaBancaria>? _cuentasBancarias;
        public IRepository<CuentaBancaria> CuentasBancarias => _cuentasBancarias ??= new Repository<CuentaBancaria>(_context);


    }
}