namespace Cepheus.Application.Features.Logistica.Maestros.CentrosCosto.Common
{
    public class CentroCostoResponse
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string PlantaCode { get; set; } = default!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
