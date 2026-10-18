using Cepheus.Domain.Contabilidad.Transacciones;

namespace Cepheus.Application.Comun.Interfaces.UnitOfWork
{
    public interface IContabilidadTransaccionesUnitOfWork
    {
        IRepository<DocumentoCompra> DocumentosCompra { get; }
        IRepository<DocumentoCompraDetalle> DocumentoCompraDetalles { get; }
        IRepository<AsientoContable> AsientosContables { get; }
        IRepository<AsientoContableDetalle> AsientoContableDetalles { get; }

    }
}