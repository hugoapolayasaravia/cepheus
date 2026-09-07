using Cepheus.Application.Comun.Interfaces;
using Cepheus.Domain.Administracion;
using Cepheus.Domain.Comunes;
using Cepheus.Infrastructure.Persistence.Repositories;
using System.Security;

namespace Cepheus.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

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
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }





}
