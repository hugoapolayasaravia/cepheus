namespace Cepheus.Application.Comun.Interfaces.UnitOfWork
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
        IAdministracionUnitOfWork Administracion { get; }


        //Comunes
        IComunesUnitOfWork Comunes { get; }


        // Logistica
        ILogisticaUnitOfWork Logistica { get; }


        // Mantenimiento
        IMantenimientoUnitOfWork Mantenimiento { get; }

        // Recursos Humanos
        IRrhhUnitOfWork Rrhh { get; }

        // Facturacion
        IFacturacionUnitOfWork Facturacion {  get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }





}
