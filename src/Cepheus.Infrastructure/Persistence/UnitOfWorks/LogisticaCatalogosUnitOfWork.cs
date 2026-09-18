using Cepheus.Application.Comun.Interfaces;
using Cepheus.Application.Comun.Interfaces.UnitOfWork;
using Cepheus.Domain.Logistica.Catalogos;
using Cepheus.Infrastructure.Persistence.ApplicationDbContexts;
using Cepheus.Infrastructure.Persistence.Repositories;

namespace Cepheus.Infrastructure.Persistence.UnitOfWorks
{
    public sealed class LogisticaCatalogosUnitOfWork : ILogisticaCatalogosUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public LogisticaCatalogosUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IRepository<Familia>? _familias;

        public IRepository<Familia> Familias => _familias ??= new Repository<Familia>(_context);


        private IRepository<SubFamilia>? _subFamilias;

        public IRepository<SubFamilia> SubFamilias => _subFamilias ??= new Repository<SubFamilia>(_context);

        
        private IRepository<UnidadMedida>? _unidadesMedida;

        public IRepository<UnidadMedida> UnidadesMedida => _unidadesMedida ??= new Repository<UnidadMedida>(_context);

        
        private IRepository<TipoCompra>? _tiposCompra;

        public IRepository<TipoCompra> TiposCompra => _tiposCompra ??= new Repository<TipoCompra>(_context);

        
        private IRepository<NotaCompra>? _notasCompra;

        public IRepository<NotaCompra> NotasCompra => _notasCompra ??= new Repository<NotaCompra>(_context);

        
        private IRepository<LugarEnvio>? _lugaresEnvio;

        public IRepository<LugarEnvio> LugaresEnvio => _lugaresEnvio ??= new Repository<LugarEnvio>(_context);

        
        private IRepository<Comprador>? _compradores;

        public IRepository<Comprador> Compradores => _compradores ??= new Repository<Comprador>(_context);

        
        private IRepository<Tramite>? _tramites;

        public IRepository<Tramite> Tramites => _tramites ??= new Repository<Tramite>(_context);

        
        private IRepository<TipoPedido>? _tiposPedido;

        public IRepository<TipoPedido> TiposPedido => _tiposPedido ??= new Repository<TipoPedido>(_context);

        
        private IRepository<UnidadNegocio>? _unidadesNegocio;

        public IRepository<UnidadNegocio> UnidadesNegocio => _unidadesNegocio ??= new Repository<UnidadNegocio>(_context);


        private IRepository<TipoVale>? _tiposVale;

        public IRepository<TipoVale> TiposVale => _tiposVale ??= new Repository<TipoVale>(_context);

        
        private IRepository<TipoArticulo>? _tiposArticulo;

        public IRepository<TipoArticulo> TiposArticulo => _tiposArticulo ??= new Repository<TipoArticulo>(_context);

        
        private IRepository<PlanArticulo>? _planesArticulo;

        public IRepository<PlanArticulo> PlanesArticulo => _planesArticulo ??= new Repository<PlanArticulo>(_context);

        private IRepository<FormaPago>? _formasPago;

        public IRepository<FormaPago> FormasPago =>  _formasPago ??= new Repository<FormaPago>(_context);
    }
}