using Cepheus.Domain.Administracion;
using Cepheus.Domain.Comunes;
using Cepheus.Domain.Logistica.Catalogos;
using Cepheus.Domain.Logistica.Maestros;
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


        //Comunes
        IRepository<Planta> Plantas { get; }
        IRepository<Moneda> Monedas { get; }
        IRepository<TipoDocumento> TiposDocumento { get; }
        IRepository<ComprobantePago> ComprobantesPago { get; }
        IRepository<Ubigeo> Ubigeos { get; }
        IRepository<TipoCambio> TiposCambio { get; }
        IRepository<ControlVentas> ControlesVentas { get; }
        IRepository<MotivoDevolucion> MotivosDevolucion { get; }
        IRepository<Banco> Bancos { get; }


        // Logistica - Catalogos
        IRepository<Familia> Familias { get; }
        IRepository<SubFamilia> SubFamilias { get; }
        IRepository<UnidadMedida> UnidadesMedida { get; }
        IRepository<TipoCompra> TiposCompra { get; }
        IRepository<NotaCompra> NotasCompra { get; }
        IRepository<LugarEnvio> LugaresEnvio { get; }
        IRepository<Comprador> Compradores { get; }
        IRepository<Tramite> Tramites { get; }
        IRepository<TipoPedido> TiposPedido { get; }
        IRepository<UnidadNegocio> UnidadesNegocio { get; }
        IRepository<TipoVale> TiposVale { get; }
        IRepository<TipoArticulo> TiposArticulo { get; }
        IRepository<PlanArticulo> PlanesArticulo { get; }
        IRepository<FormaPago> FormasPago { get; }

        // Logistica - Maestros
        IRepository<Proveedor> Proveedores { get; }
        IRepository<ProveedorDireccion> ProveedorDirecciones { get; }
        IRepository<ProveedorContacto> ProveedorContactos { get; }
        IRepository<ProveedorCuenta> ProveedorCuentas { get; }
        IRepository<ProveedorCondicion> ProveedorCondiciones { get; }
        IRepository<Articulo> Articulos { get; }
        IRepository<ArticuloProveedor> ArticuloProveedores { get; }
        IRepository<ArticuloStock> StockArticulos { get; }
        IRepository<CentroCosto> CentrosCosto { get; }
        IRepository<SubCentroCosto> SubCentrosCosto { get; }
        IRepository<Transportista> Transportistas { get; }
        IRepository<Vehiculo> Vehiculos { get; }
        IRepository<Conductor> Conductores { get; }
        IRepository<ControlCierre> ControlCierres { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }





}
