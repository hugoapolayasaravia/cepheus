namespace Cepheus.Application.Features.Facturacion.Maestros.Choferes.Common
{
    public class ChoferResponse
    {
        public string TransportistaCode { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string DriverLicenseNumber { get; set; } = default!;
        public string? Observations { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}
