namespace Cepheus.Application.Comun.Interfaces.UnitOfWork
{
    public interface ILogisticaUnitOfWork
    {
        ILogisticaCatalogosUnitOfWork Catalogos { get; }

        ILogisticaMaestrosUnitOfWork Maestros { get; }
    }
}
