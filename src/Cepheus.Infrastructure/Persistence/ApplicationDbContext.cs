using Cepheus.Application.Comun.Interfaces;
using Cepheus.Domain.Administracion;
using Cepheus.Domain.Comun;
using Cepheus.Domain.Comunes;
using Cepheus.Domain.Logistica.Catalogos;
using Cepheus.Domain.Logistica.Maestros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Cepheus.Infrastructure.Persistence
{

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        // Administracion
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<RoleUser> RoleUsers => Set<RoleUser>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Modulo> Modulos => Set<Modulo>();
        public DbSet<Submodulo> Submodulos => Set<Submodulo>();
        public DbSet<Programa> Programas => Set<Programa>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<PermissionRole> PermissionRoles => Set<PermissionRole>();

        // Comunes
        public DbSet<Planta> Plantas => Set<Planta>();
        public DbSet<Moneda> Monedas => Set<Moneda>();
        public DbSet<TipoDocumento> TiposDocumento => Set<TipoDocumento>();
        public DbSet<ComprobantePago> ComprobantesPago => Set<ComprobantePago>();
        public DbSet<Ubigeo> Ubigeos => Set<Ubigeo>();
        public DbSet<TipoCambio> TiposCambio => Set<TipoCambio>();
        public DbSet<ControlVentas> ControlesVentas => Set<ControlVentas>();
        public DbSet<MotivoDevolucion> MotivosDevolucion => Set<MotivoDevolucion>();
        public DbSet<Banco> Bancos => Set<Banco>();


        // Logistica.Catalogos
        public DbSet<Familia> Familias => Set<Familia>();
        public DbSet<SubFamilia> SubFamilias => Set<SubFamilia>();
        public DbSet<UnidadMedida> UnidadesMedida => Set<UnidadMedida>();
        public DbSet<TipoCompra> TiposCompra => Set<TipoCompra>();
        public DbSet<NotaCompra> NotasCompra => Set<NotaCompra>();
        public DbSet<LugarEnvio> LugaresEnvio => Set<LugarEnvio>();
        public DbSet<Comprador> Compradores => Set<Comprador>();
        public DbSet<Tramite> Tramites => Set<Tramite>();
        public DbSet<TipoPedido> TiposPedido => Set<TipoPedido>();
        public DbSet<UnidadNegocio> UnidadesNegocio => Set<UnidadNegocio>();
        public DbSet<TipoVale> TiposVale => Set<TipoVale>();
        public DbSet<TipoArticulo> TiposArticulo => Set<TipoArticulo>();
        public DbSet<PlanArticulo> PlanesArticulo => Set<PlanArticulo>();
        public DbSet<FormaPago> FormasPago => Set<FormaPago>();

        // Logistica.Maestros
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<ProveedorDireccion> ProveedorDirecciones => Set<ProveedorDireccion>();
        public DbSet<ProveedorContacto> ProveedorContactos => Set<ProveedorContacto>();
        public DbSet<ProveedorCuenta> ProveedorCuentas => Set<ProveedorCuenta>();
        public DbSet<ProveedorCondicion> ProveedorCondiciones => Set<ProveedorCondicion>();
        public DbSet<Articulo> Articulos => Set<Articulo>();
        public DbSet<ArticuloProveedor> ArticuloProveedores => Set<ArticuloProveedor>();
        public DbSet<ArticuloStock> StockArticulos => Set<ArticuloStock>();
        public DbSet<CentroCosto> CentrosCosto => Set<CentroCosto>();
        public DbSet<SubCentroCosto> SubCentrosCosto => Set<SubCentroCosto>();
        public DbSet<Transportista> Transportistas => Set<Transportista>();
        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
        public DbSet<Conductor> Conductores => Set<Conductor>();
        public DbSet<ControlCierre> ControlCierres => Set<ControlCierre>();


        DatabaseFacade IApplicationDbContext.Database => base.Database;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas las IEntityTypeConfiguration<> del ensamblado
            // (Configurations/Administracion/*, Configurations/Logistica/* a futuro)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Auditoría automática: setea CreatedAt/CreatedBy en entidades nuevas
        /// y UpdatedAt/UpdatedBy en entidades modificadas, para toda entidad
        /// que implemente IAuditableEntity. Los handlers NO deben setear
        /// estos campos manualmente.
        /// </summary>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var utcNow = DateTime.UtcNow;
            var currentUserName = BuildCurrentUserAuditLabel();

            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = utcNow;
                        entry.Entity.CreatedBy = currentUserName;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = utcNow;
                        entry.Entity.UpdatedBy = currentUserName;
                        // Nunca se debe pisar CreatedAt/CreatedBy en un Update
                        entry.Property(x => x.CreatedAt).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// "Nombre Apellido (email)" — el email desambigua entre dos usuarios
        /// con el mismo nombre y apellido en el registro de auditoría.
        /// "System" si no hay usuario autenticado (ej. bootstrap de Register).
        /// </summary>
        private string BuildCurrentUserAuditLabel()
        {
            var fullName = _currentUserService.FullName;
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "System";
            }

            var email = _currentUserService.Email;
            return string.IsNullOrWhiteSpace(email) ? fullName : $"{fullName} ({email})";
        }
    }






}
