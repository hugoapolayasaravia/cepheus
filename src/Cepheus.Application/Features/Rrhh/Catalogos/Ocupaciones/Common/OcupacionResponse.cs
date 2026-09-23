namespace Cepheus.Application.Features.Rrhh.Catalogos.Ocupaciones.Common
{
    public class OcupacionResponse
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] RowVersion { get; set; } = default!;
    }
}