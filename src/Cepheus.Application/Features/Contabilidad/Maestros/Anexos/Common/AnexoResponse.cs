namespace Cepheus.Application.Features.Contabilidad.Maestros.Anexos.Common
{
    public class AnexoResponse
    {
        public string TipoAnexoCode { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Name { get; set; }
        public string LinkAccount1Code { get; set; } = default!;
        public string LinkAccount2Code { get; set; } = default!;
        public string? Flag { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
