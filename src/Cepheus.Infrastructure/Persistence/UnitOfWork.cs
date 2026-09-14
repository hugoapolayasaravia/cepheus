using Cepheus.Application.Comun.Interfaces;
using Cepheus.Domain.Administracion;
using Cepheus.Domain.Comunes;
using Cepheus.Domain.Logistica.Catalogos;
using Cepheus.Domain.Logistica.Maestros;
using Cepheus.Infrastructure.Persistence.Repositories;
using System.Security;

namespace Cepheus.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Administracion
        private IRepository<User>? _users;
        private IRepository<Role>? _roles;
        private IRepository<RoleUser>? _roleUsers;
        private IRepository<RefreshToken>? _refreshTokens;
        private IRepository<Modulo>? _modulos;
        private IRepository<Submodulo>? _submodulos;
        private IRepository<Programa>? _programas;
        private IRepository<Permission>? _permissions;
        private IRepository<PermissionRole>? _permissionRoles;

        //Comunes
        private IRepository<Planta>? _plantas;
        private IRepository<Moneda>? _monedas;
        private IRepository<TipoDocumento>? _tiposDocumento;
        private IRepository<ComprobantePago>? _comprobantesPago;
        private IRepository<Ubigeo>? _ubigeos;
        private IRepository<TipoCambio>? _tiposCambio;
        private IRepository<ControlVentas>? _controlesVentas;
        private IRepository<MotivoDevolucion>? _motivosDevolucion;
        private IRepository<Banco>? _bancos;


        // Logistica - Catalogos
        private IRepository<Familia>? _familias;
        private IRepository<SubFamilia>? _subFamilias;
        private IRepository<UnidadMedida>? _unidadesMedida;
        private IRepository<TipoCompra>? _tiposCompra;
        private IRepository<NotaCompra>? _notasCompra;
        private IRepository<LugarEnvio>? _lugaresEnvio;
        private IRepository<Comprador>? _compradores;
        private IRepository<Tramite>? _tramites;
        private IRepository<TipoPedido>? _tiposPedido;
        private IRepository<UnidadNegocio>? _unidadesNegocio;
        private IRepository<TipoVale>? _tiposVale;
        private IRepository<TipoArticulo>? _tiposArticulo;
        private IRepository<PlanArticulo>? _planesArticulo;
        private IRepository<FormaPago>? _formasPago;

        // Logistica - Maestros
        private IRepository<Proveedor>? _proveedores;
        private IRepository<ProveedorDireccion>? _proveedorDirecciones;
        private IRepository<ProveedorContacto>? _proveedorContactos;
        private IRepository<ProveedorCuenta>? _proveedorCuentas;
        private IRepository<ProveedorCondicion>? _proveedorCondiciones;
        private IRepository<Articulo>? _articulos;
        private IRepository<ArticuloProveedor>? _articuloProveedores;
        private IRepository<ArticuloStock>? _stockArticulos;
        private IRepository<CentroCosto>? _centrosCosto;
        private IRepository<SubCentroCosto>? _subCentrosCosto;
        private IRepository<Transportista>? _transportistas;
        private IRepository<Vehiculo>? _vehiculos;
        private IRepository<Conductor>? _conductores;
        private IRepository<ControlCierre>? _controlCierres;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<User> Users => _users ??= new Repository<User>(_context);
        public IRepository<Role> Roles => _roles ??= new Repository<Role>(_context);
        public IRepository<RoleUser> RoleUsers => _roleUsers ??= new Repository<RoleUser>(_context);
        public IRepository<RefreshToken> RefreshTokens => _refreshTokens ??= new Repository<RefreshToken>(_context);
        public IRepository<Modulo> Modulos => _modulos ??= new Repository<Modulo>(_context);
        public IRepository<Submodulo> Submodulos => _submodulos ??= new Repository<Submodulo>(_context);
        public IRepository<Programa> Programas => _programas ??= new Repository<Programa>(_context);
        public IRepository<Permission> Permissions => _permissions ??= new Repository<Permission>(_context);
        public IRepository<PermissionRole> PermissionRoles => _permissionRoles ??= new Repository<PermissionRole>(_context);


        //Comunes
        public IRepository<Planta> Plantas => _plantas ??= new Repository<Planta>(_context);
        public IRepository<Moneda> Monedas => _monedas ??= new Repository<Moneda>(_context);
        public IRepository<TipoDocumento> TiposDocumento => _tiposDocumento ??= new Repository<TipoDocumento>(_context);
        public IRepository<ComprobantePago> ComprobantesPago => _comprobantesPago ??= new Repository<ComprobantePago>(_context);
        public IRepository<Ubigeo> Ubigeos => _ubigeos ??= new Repository<Ubigeo>(_context);
        public IRepository<TipoCambio> TiposCambio => _tiposCambio ??= new Repository<TipoCambio>(_context);
        public IRepository<ControlVentas> ControlesVentas => _controlesVentas ??= new Repository<ControlVentas>(_context);
        public IRepository<MotivoDevolucion> MotivosDevolucion => _motivosDevolucion ??= new Repository<MotivoDevolucion>(_context);
        public IRepository<Banco> Bancos => _bancos ??= new Repository<Banco>(_context);

        // Logistica - Catalogos
        public IRepository<Familia> Familias => _familias ??= new Repository<Familia>(_context);
        public IRepository<SubFamilia> SubFamilias => _subFamilias ??= new Repository<SubFamilia>(_context);
        public IRepository<UnidadMedida> UnidadesMedida => _unidadesMedida ??= new Repository<UnidadMedida>(_context);
        public IRepository<TipoCompra> TiposCompra => _tiposCompra ??= new Repository<TipoCompra>(_context);
        public IRepository<NotaCompra> NotasCompra => _notasCompra ??= new Repository<NotaCompra>(_context);
        public IRepository<LugarEnvio> LugaresEnvio => _lugaresEnvio ??= new Repository<LugarEnvio>(_context);
        public IRepository<Comprador> Compradores => _compradores ??= new Repository<Comprador>(_context);
        public IRepository<Tramite> Tramites => _tramites ??= new Repository<Tramite>(_context);
        public IRepository<TipoPedido> TiposPedido => _tiposPedido ??= new Repository<TipoPedido>(_context);
        public IRepository<UnidadNegocio> UnidadesNegocio => _unidadesNegocio ??= new Repository<UnidadNegocio>(_context);
        public IRepository<TipoVale> TiposVale => _tiposVale ??= new Repository<TipoVale>(_context);
        public IRepository<TipoArticulo> TiposArticulo => _tiposArticulo ??= new Repository<TipoArticulo>(_context);
        public IRepository<PlanArticulo> PlanesArticulo => _planesArticulo ??= new Repository<PlanArticulo>(_context);
        public IRepository<FormaPago> FormasPago => _formasPago ??= new Repository<FormaPago>(_context);

        // Logistica - Maestros
        public IRepository<Proveedor> Proveedores => _proveedores ??= new Repository<Proveedor>(_context);
        public IRepository<ProveedorDireccion> ProveedorDirecciones => _proveedorDirecciones ??= new Repository<ProveedorDireccion>(_context);
        public IRepository<ProveedorContacto> ProveedorContactos => _proveedorContactos ??= new Repository<ProveedorContacto>(_context);
        public IRepository<ProveedorCuenta> ProveedorCuentas => _proveedorCuentas ??= new Repository<ProveedorCuenta>(_context);
        public IRepository<ProveedorCondicion> ProveedorCondiciones => _proveedorCondiciones ??= new Repository<ProveedorCondicion>(_context);
        public IRepository<Articulo> Articulos => _articulos ??= new Repository<Articulo>(_context);
        public IRepository<ArticuloProveedor> ArticuloProveedores => _articuloProveedores ??= new Repository<ArticuloProveedor>(_context);
        public IRepository<ArticuloStock> StockArticulos => _stockArticulos ??= new Repository<ArticuloStock>(_context);
        public IRepository<CentroCosto> CentrosCosto => _centrosCosto ??= new Repository<CentroCosto>(_context);
        public IRepository<SubCentroCosto> SubCentrosCosto => _subCentrosCosto ??= new Repository<SubCentroCosto>(_context);
        public IRepository<Transportista> Transportistas => _transportistas ??= new Repository<Transportista>(_context);
        public IRepository<Vehiculo> Vehiculos => _vehiculos ??= new Repository<Vehiculo>(_context);
        public IRepository<Conductor> Conductores => _conductores ??= new Repository<Conductor>(_context);
        public IRepository<ControlCierre> ControlCierres => _controlCierres ??= new Repository<ControlCierre>(_context);

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }





}
