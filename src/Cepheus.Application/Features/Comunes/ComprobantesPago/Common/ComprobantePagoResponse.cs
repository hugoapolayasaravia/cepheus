namespace Cepheus.Application.Features.Comunes.ComprobantesPago.Common
{
    public class ComprobantePagoResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string SunatCode { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string ShortName { get; set; } = default!;
        public string? Description { get; set; }
        public bool RequiresRuc { get; set; }
        public bool RequiresAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
