namespace Cepheus.Domain.Facturacion.Enum
{
    /// <summary>
    /// Tipo de cotización.
    ///
    /// Legacy: dbo.CotizacionResumen.Tipo_Cot (char(1), comentario del DDL:
    /// "Cotizacion, Recotizacion, Actualizacion, Copia (puede ser Enum)") -> enum,
    /// catálogo cerrado y corto.
    ///
    /// PENDIENTE CONFIRMAR: el default del legacy es 'N'
    /// (DF_CotizacionResumen_Tipo_Cot), que no corresponde a ninguna de las 4
    /// opciones documentadas en el comentario de la columna (¿"Nueva" como un
    /// quinto valor implícito, o el default nunca se usó en la práctica?). Se
    /// modela Nueva = 1 como valor por defecto tentativo; confirmar antes de
    /// escribir el ETL de migración.
    /// </summary>
    public enum TipoCotizacion
    {
        Nueva = 1,
        Cotizacion = 2,
        Recotizacion = 3,
        Actualizacion = 4,
        Copia = 5
    }
}
