namespace Cepheus.Application.Features.Logistica.Catalogos.UnidadesNegocio.Common
{
    public class UnidadNegocioResponse
    {
        public string Code { get; set; } = default!;
        public string? Name { get; set; }
        public string? ParentCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}