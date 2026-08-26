using Cepheus.Application.Comun.Interfaces;
using Cepheus.Domain.Administracion;
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

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }





}
