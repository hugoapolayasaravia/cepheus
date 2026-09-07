using Cepheus.Domain.Comunes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepheus.Infrastructure.Persistence.Configurations.Comunes
{
    public class ComprobantePagoConfiguration : IEntityTypeConfiguration<ComprobantePago>
    {
        public void Configure(EntityTypeBuilder<ComprobantePago> builder)
        {
            builder.ToTable("ComprobantesPago", schema: "comun");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => x.Code).IsUnique();

            builder.Property(x => x.SunatCode)
                .IsRequired()
                .HasMaxLength(2);

            builder.HasIndex(x => x.SunatCode).IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ShortName)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Description)
                .HasMaxLength(255);

            builder.Property(x => x.RequiresRuc)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.RequiresAddress)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(250);

            builder.Property(x => x.UpdatedBy)
                .HasMaxLength(250);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
