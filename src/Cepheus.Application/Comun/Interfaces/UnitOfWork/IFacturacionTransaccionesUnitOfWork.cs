

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

        IRepository<HojaCorte> HojasCorte { get; }
        IRepository<HojaCorteDetalle> HojasCorteDetalle { get; }

        IRepository<SolicitudNotaCredito> SolicitudesNotaCredito { get; }
        IRepository<SolicitudNotaCreditoDetalle> SolicitudesNotaCreditoDetalle { get; }
        IRepository<SolicitudNotaCreditoGuia> SolicitudesNotaCreditoGuias { get; }
        IRepository<SolicitudNotaCreditoArchivo> SolicitudesNotaCreditoArchivos { get; }
        IRepository<SolicitudNotaCreditoAprobacion> SolicitudesNotaCreditoAprobaciones { get; }

        IRepository<NotaCreditoVenta> NotasCreditoVenta { get; }
        IRepository<NotaCreditoVentaDetalle> NotasCreditoVentaDetalle { get; }
    }
}