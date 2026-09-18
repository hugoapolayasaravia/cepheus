namespace Cepheus.Application.Features.Mantenimiento.Maestros.SubCentrosEjecutores.Common
{
    public class SubCentroEjecutorResponse
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string CentroEjecutorCode { get; set; } = default!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
