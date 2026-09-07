namespace Cepheus.Application.Features.Comunes.TiposCambio.Common
{
    public class TipoCambioResponse
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal SellRate { get; set; }
        public decimal BuyRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
