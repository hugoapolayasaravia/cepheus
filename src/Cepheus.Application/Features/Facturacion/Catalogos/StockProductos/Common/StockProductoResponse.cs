namespace Cepheus.Application.Features.Facturacion.Catalogos.StockProductos.Common
{
    public class StockProductoResponse
    {
        public long Id { get; set; }
        public string PlantaCode { get; set; } = default!;
        public string TipoProductoCode { get; set; } = default!;
        public string ProductoCode { get; set; } = default!;
        public decimal Cantidad { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
