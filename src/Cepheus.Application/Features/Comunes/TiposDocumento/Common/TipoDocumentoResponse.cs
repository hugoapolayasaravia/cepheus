namespace Cepheus.Application.Features.Comunes.TiposDocumento.Common
{
    public class TipoDocumentoResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? ShortName { get; set; }
        public string? SunatCode { get; set; }
        public bool AffectsIgv { get; set; }
        public bool IsNonTaxable { get; set; }
        public bool AffectsIncomeTax { get; set; }
        public bool AffectsFonavi { get; set; }
        public bool IsService { get; set; }
        public bool AffectsForeignIgv { get; set; }
        public bool AvailableForPurchaseOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
