using Cepheus.Domain.Comun;

namespace Cepheus.Domain.Comunes
{
    /// <summary>
    /// Tipo de documento para clasificación tributaria/contable de comprobantes
    /// (afectación a IGV, Renta, si es servicio, si aplica en orden de compra, etc.).
    /// Entidad maestra compartida entre módulos (Compras, Ventas, Contabilidad).
    ///
    /// Legacy: dbo.Ttipdoc (SQL Server).
    ///
    /// IMPORTANTE - aclaración de alcance: el comentario original del script SQL
    /// listaba este punto como "Tipo de documento (ejemplo DNI/RUC/CE)", pero las
    /// columnas reales de Ttipdoc (igv_tdo, renta_tdo, fonavi_tdo, servicio_tdo,
    /// En_ocompra, etc.) NO corresponden a tipo de documento de identidad, sino a
    /// una clasificación TRIBUTARIA de documentos (usada típicamente para marcar
    /// cómo afecta un comprobante de compra al IGV/Renta). Modelé la entidad según
    /// las columnas reales de la tabla. Si además necesitas un catálogo de "Tipo
    /// de Documento de Identidad" (DNI/RUC/CE/Pasaporte — catálogo 06 SUNAT), esa
    /// es una entidad distinta que no existe en el script provisto y habría que
    /// crear aparte (avísame y la agrego).
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
    /// Nota: Fonavi fue derogado en el Perú (Ley 26969, 1998) y no tiene vigencia
    /// tributaria actual. Se mantiene AffectsFonavi únicamente por continuidad de
    /// datos históricos/reportes legacy que aún lo referencian; no debería usarse
    /// en lógica nueva.
    ///
    /// IsActive no existe en la tabla legacy (Ttipdoc no maneja soft-status); se
    /// agrega para mantener consistencia con el resto de catálogos del sistema.
    /// </summary>
    public class TipoDocumento : IAuditableEntity
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