// Cepheus.Domain/Logistica/Transacciones/OrdenCompraPedidoOrigen.cs
using Cepheus.Domain.Comun;

namespace Cepheus.Domain.Logistica.Transacciones
{
    /// <summary>
    /// Vínculo a nivel de línea entre una Orden de Compra y los Pedidos que
    /// la originaron — mismo patrón confirmado que CotizacionPedidoOrigen.
    /// Control manual (sin bloqueo), igual criterio ya usado en Cotización.
    /// </summary>
    public class OrdenCompraPedidoOrigen : IAuditableEntity
    {
        public string PlantaCode { get; set; } = default!;
        public string OrdenCompraCode { get; set; } = default!;
        public string ArticuloCode { get; set; } = default!;
        public OrdenCompraDetalle OrdenCompraDetalle { get; set; } = default!;

        public string PedidoCode { get; set; } = default!;
        public int PedidoItemNumber { get; set; }
        public PedidoDetalle PedidoDetalle { get; set; } = default!;

        public decimal CantidadTomada { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public byte[] RowVersion { get; set; } = default!;
    }
}