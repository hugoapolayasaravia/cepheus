namespace Cepheus.Application.Features.Facturacion.Catalogos.PreciosProducto.Common
{
    public class PrecioProductoResponse
    {
        public string FleteCode { get; set; } = default!;
        public string ProductoTipoCode { get; set; } = default!;
        public string ProductoCode { get; set; } = default!;
        public string CurrencyTypeCode { get; set; } = default!;
        public string CurrencyCode { get; set; } = default!;
        public decimal Amount { get; set; }
        public decimal TransportAmount { get; set; }
        public decimal FreightAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
