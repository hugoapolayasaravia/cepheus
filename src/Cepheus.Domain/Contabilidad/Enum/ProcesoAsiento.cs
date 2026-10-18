namespace Cepheus.Domain.Contabilidad.Enum
{
    /// <summary>
    /// Proceso contable que usa una plantilla de asiento.
    ///   ProvisionCompraNotaIngreso: nota de ingreso por compra -> documento de compra + asiento de provisión
    ///                               (legacy: fc_genasiprocompras, asiento tipo 02).
    ///   TransferenciaNotaIngreso:   nota de ingreso por transferencia entre plantas -> asiento directo
    ///                               (legacy: evento ue_transferencia de la ventana de pase a contabilidad).
    /// </summary>
    public enum ProcesoAsiento
    {
        ProvisionCompraNotaIngreso = 1,
        TransferenciaNotaIngreso = 2
    }
}
