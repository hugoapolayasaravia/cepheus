namespace Cepheus.Application.Features.Comunes.MotivosDevolucion.Common
{
    public class MotivoDevolucionResponse
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool AffectsStock { get; set; }
        public bool EsVenta { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
