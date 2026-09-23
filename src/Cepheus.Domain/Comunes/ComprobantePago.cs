using Cepheus.Domain.Comun;

namespace Cepheus.Domain.Comunes
{
    /// <summary>
    /// Comprobante de pago (Factura, Boleta, Nota de Crédito, etc.). Catálogo
    /// maestro compartido entre módulos (Ventas, Compras, Facturación).
    ///
    /// Legacy: tabla "comprobante_pago" (MySQL).
    /// Mapeo de columnas legacy -> propiedades profesionales:
    ///   codigo               -> Code
    ///   codigo_sunat         -> SunatCode        (catálogo 01 SUNAT: 01=Factura, 03=Boleta, 07=N.Crédito, etc.)
    ///   nombre               -> Name
    ///   abreviatura          -> ShortName
    ///   descripcion          -> Description
    ///   requiere_ruc         -> RequiresRuc
    ///   requiere_direccion   -> RequiresAddress
    ///   estado               -> IsActive
    ///   fecha_creacion       -> CreatedAt (vía IAuditableEntity)
    ///   fecha_actualizacion  -> UpdatedAt (vía IAuditableEntity)
    ///
    /// </summary>
    public class ComprobantePago : IAuditableEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = default!;
        public string SunatCode { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string ShortName { get; set; } = default!;
        public string? Description { get; set; }

        public bool RequiresRuc { get; set; }
        public bool RequiresAddress { get; set; }

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