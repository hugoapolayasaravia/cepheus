using Cepheus.Domain.Mantenimiento.Transacciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepheus.Infrastructure.Persistence.Configurations.Mantenimiento.Transacciones
{
    public class OTResponsableConfiguration : IEntityTypeConfiguration<OTResponsable>
    {
        public void Configure(EntityTypeBuilder<OTResponsable> builder)
        {
            builder.ToTable("OTResponsables", schema: "mantenimiento");

            builder.HasKey(x => new { x.PlantaCode, x.OrdenTrabajoCode, x.FechaProceso, x.TrabajadorCode });

            builder.Property(x => x.PlantaCode).IsRequired().HasMaxLength(2);
            builder.Property(x => x.OrdenTrabajoCode).IsRequired().HasMaxLength(6);

            builder.HasOne(x => x.OrdenTrabajo)
                .WithMany()
                .HasForeignKey(x => new { x.PlantaCode, x.OrdenTrabajoCode })
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.FechaProceso).IsRequired();

            // Sin FK real todavía: Trabajador no existe como tabla
            builder.Property(x => x.TrabajadorCode).IsRequired().HasMaxLength(5);

            builder.Property(x => x.TiempoProceso).IsRequired().HasColumnType("decimal(12,5)").HasDefaultValue(0);
            builder.Property(x => x.Basico).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(x => x.CostoTotal).IsRequired().HasColumnType("decimal(18,2)").HasDefaultValue(0);

            builder.Property(x => x.CreatedBy).HasMaxLength(250);
            builder.Property(x => x.UpdatedBy).HasMaxLength(250);

            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
