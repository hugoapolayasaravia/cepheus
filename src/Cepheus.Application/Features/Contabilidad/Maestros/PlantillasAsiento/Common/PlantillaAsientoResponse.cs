using Cepheus.Domain.Contabilidad.Enum;

namespace Cepheus.Application.Features.Contabilidad.Maestros.PlantillasAsiento.Common
{
    public class PlantillaAsientoLineaResponse
    {
        public int Order { get; set; }
        public ConceptoAsiento Concept { get; set; }
        public NaturalezaAsiento Nature { get; set; }
        public OrigenCuentaAsiento AccountSource { get; set; }
        public string? AccountCode { get; set; }
        public OrigenAnexoAsiento AnnexSource { get; set; }
        public OrigenDescripcionAsiento DescriptionSource { get; set; }
        public bool InvertsOnCreditNote { get; set; }
        public bool IsDestination { get; set; }
        public TipoContabilidad AccountingType { get; set; }
    }

    public class PlantillaAsientoResponse
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ProcesoAsiento Process { get; set; }
        public string TipoAsientoCode { get; set; } = default!;
        public string? PurchaseAccountCode { get; set; }
        public bool IsActive { get; set; }
        public List<PlantillaAsientoLineaResponse> Lines { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
