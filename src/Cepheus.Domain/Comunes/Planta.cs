using Cepheus.Domain.Comun;

namespace Cepheus.Domain.Comunes
{
    /// <summary>
    /// Planta / sede de trabajo (ej. Planta Villa, Planta Santa Anita). Entidad
    /// maestra compartida entre módulos (Logística, Ventas, Compras, etc.).
    ///
    /// Legacy: dbo.MPlantas (SQL Server).
    /// Mapeo de columnas legacy -> propiedades profesionales:
    ///   Codigo_pla        -> Code
    ///   Descripcion_pla   -> Name
    ///   Razon_Pla         -> LegalName
    ///   direccion_pla     -> Address
    ///   direccion_pla2    -> AddressComplement
    ///   direccion_ubi     -> UbigeoCode (FK pendiente a Comunes.Ubigeo, ver punto 5)
    ///   responsable_pla   -> ManagerName
    ///   almacen           -> HasWarehouse      ('S'/'N' -> bool)
    ///   Produccion        -> IsProductionPlant ('S'/'N' -> bool)
    ///   proyecto_sn       -> IsProject         ('S'/'N' -> bool)
    ///   flg_aprobaciones  -> RequiresApprovals
    ///   detraccion_pla    -> AppliesDetraction
    ///   codigo_est        -> StatusCode (catálogo de estados aún no modelado)
    ///   Estado_pla        -> IsActive ('A' -> true)
    ///
    /// Legacy EXCLUIDO deliberadamente de esta entidad (no es dato maestro,
    /// pertenece a otro contexto y se modelará como entidad propia más adelante):
    ///   - Correlativos de comprobantes por planta: numero_gve, numero_fve,
    ///     numero_dve, numero_bve, numero_cve, numero_let, numero_ret,
    ///     numero_ctr, numero_fct, numero_prf, numero_lad, guia_num,
    ///     guia_prima, guia_numdev
    ///     -> futura entidad "PlantaSerieComprobante" en módulo Facturación,
    ///        relacionada con Comunes.ComprobantePago.
    ///   - Montos y presupuestos: monto_max_sol, monto_max_dol,
    ///     presupuesto_ing, presupuesto_mon, presupuesto_con
    ///     -> futuro módulo Presupuestos/Aprobaciones.
    ///   - Códigos de integración/config sin significado claro fuera de su
    ///     módulo original: codigo_ciu, codigo_fox, codigo_fac, codigo_log,
    ///     codigo_pro, codigo_pla_bol, COD_PLANTA_CA, fecha_pro.
    /// </summary>
    public class Planta : IAuditableEntity
    {

        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? LegalName { get; set; }

        public string Address { get; set; } = default!;
        public string? AddressComplement { get; set; }
        public string? UbigeoCode { get; set; }

        public string? ManagerName { get; set; }

        public bool HasWarehouse { get; set; }
        public bool IsProductionPlant { get; set; }
        public bool IsProject { get; set; }
        public bool RequiresApprovals { get; set; }
        public bool AppliesDetraction { get; set; }

        public string? StatusCode { get; set; }
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