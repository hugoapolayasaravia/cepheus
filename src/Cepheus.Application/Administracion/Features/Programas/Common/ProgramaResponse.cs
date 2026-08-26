namespace Cepheus.Application.Administracion.Features.Programas.Common
{
    public class ProgramaResponse
    {
        public int Id { get; set; }
        public int SubmoduloId { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Icon { get; set; }
        public string? Tooltip { get; set; }
        public string? Route { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
        public List<PermissionSummary> Permissions { get; set; } = new();
    }


}
