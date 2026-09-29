// Cepheus.Domain/Logistica/Enum/EstadoPedidoDetalle.cs
namespace Cepheus.Domain.Logistica.Enum
{
    /// <summary>
    /// Estado de una línea de Pedido (PedidoDetalle). Reemplaza a
    /// dbo.MPedidoDet.Codigo_Est del legacy (3 valores).
    ///
    /// Mapeo de valores legacy:
    ///   01 Pendiente -> Pendiente
    ///   04 Anulado   -> Anulado
    ///   16 En Compra -> EnCompra
    ///
    /// Toda línea nueva nace en Pendiente.
    /// </summary>
    public enum EstadoPedidoDetalle
    {
        Pendiente = 0,
        Anulado = 1,
        EnCompra = 2
    }
}