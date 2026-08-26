using Cepheus.Domain.Administracion;
using System.Security;

namespace Cepheus.Application.Comun.Interfaces
{
    /// <summary>
    /// UnitOfWork único para toda la solución. Expone un repositorio por entidad
    /// (mismo patrón que _uow.LogPlantClosingControls / _uow.Controls en Logística).
    /// A medida que se agreguen módulos (Logistica, Ventas), sus repositorios se
    /// suman acá como nuevas propiedades.
    /// </summary>
    public interface IUnitOfWork
    {
        // Administracion
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<RoleUser> RoleUsers { get; }
        IRepository<RefreshToken> RefreshTokens { get; }
        IRepository<Modulo> Modulos { get; }
        IRepository<Submodulo> Submodulos { get; }
        IRepository<Programa> Programas { get; }
        IRepository<Permission> Permissions { get; }
        IRepository<PermissionRole> PermissionRoles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }





}
