using Cepheus.Domain.Comun;

namespace Cepheus.Domain.Comunes
{
    /// <summary>
    /// Tipo de documento de Identidad 
    ///
    /// Legacy: dbo.Ttipdoc (SQL Server).
    ///
    /// Mapeo de columnas legacy -> propiedades profesionales:
    ///   Codigo_tdo        -> Code
    ///   Descripcion_tdo   -> Name
    ///   DesAbreviada_tdo  -> ShortName
    ///   sunat_tdo         -> SunatCode          (referencia a catálogo SUNAT relacionado)
    ///   igv_tdo           -> AffectsIgv
    ///   nograbable_tdo    -> IsNonTaxable
    ///   renta_tdo         -> AffectsIncomeTax
    ///   fonavi_tdo        -> AffectsFonavi       (ver nota de deprecación abajo)
    ///   servicio_tdo      -> IsService
    ///   igvext_tdo        -> AffectsForeignIgv
    ///   En_ocompra        -> AvailableForPurchaseOrder
    ///
    ///
    /// </summary>
    public class TipoDocumento : IAuditableEntity
    {
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

        public bool IsActive { get; set; } = true;

        // Auditoría (IAuditableEntity)
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        // Concurrencia optimista
        public byte[] RowVersion { get; set; } = default!;
    }
}