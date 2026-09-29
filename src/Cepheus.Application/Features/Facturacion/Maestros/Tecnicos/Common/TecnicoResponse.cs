namespace Cepheus.Application.Features.Facturacion.Maestros.Tecnicos.Common
{
    public class TecnicoResponse
    {
        public string TrabajadorCode { get; set; } = default!;
        public string? TrabajadorNombre { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
