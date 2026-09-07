using Cepheus.Domain.Comunes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepheus.Infrastructure.Persistence.Configurations.Comunes
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.ToTable("TiposDocumento", schema: "comun");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(2);

            builder.HasIndex(x => x.Code).IsUnique();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ShortName)
                .HasMaxLength(3);

            builder.Property(x => x.SunatCode)
                .HasMaxLength(2);

            builder.Property(x => x.AffectsIgv).IsRequired();
            builder.Property(x => x.IsNonTaxable).IsRequired();
            builder.Property(x => x.AffectsIncomeTax).IsRequired();
            builder.Property(x => x.AffectsFonavi).IsRequired();
            builder.Property(x => x.IsService).IsRequired();
            builder.Property(x => x.AffectsForeignIgv).IsRequired();

            builder.Property(x => x.AvailableForPurchaseOrder)
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
