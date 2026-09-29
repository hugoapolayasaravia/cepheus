

using Cepheus.Domain.Facturacion.Transacciones;

namespace Cepheus.Application.Comun.Interfaces.UnitOfWork
{
    public interface IFacturacionTransaccionesUnitOfWork
    {

        IRepository<Cotizacion> Cotizaciones { get; }
        IRepository<CotizacionDetalle> CotizacionesDetalle { get; }
        IRepository<CotizacionNota> CotizacionesNotas { get; }
        IRepository<CotizacionMetradoResumen> CotizacionesMetradoResumen { get; }
        IRepository<CotizacionMetradoDetalle> CotizacionesMetradoDetalle { get; }



    }
}