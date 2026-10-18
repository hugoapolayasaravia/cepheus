using Cepheus.Domain.Contabilidad.Enum;

namespace Cepheus.Application.Features.Contabilidad.Maestros.PlantillasAsiento.Common
{
    public interface IPlantillaAsientoCabecera
    {
        string Name { get; }
        ProcesoAsiento Process { get; }
        string TipoAsientoCode { get; }
        string? PurchaseAccountCode { get; }
        List<PlantillaAsientoLineaInput> Lines { get; }
    }
}
