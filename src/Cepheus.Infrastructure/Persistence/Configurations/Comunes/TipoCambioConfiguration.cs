using Cepheus.Domain.Comunes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepheus.Infrastructure.Persistence.Configurations.Comunes
{
    public class TipoCambioConfiguration : IEntityTypeConfiguration<TipoCambio>
    {
        public void Configure(EntityTypeBuilder<TipoCambio> builder)
        {
            builder.ToTable("TiposCambio", schema: "comun");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnType("date");

            builder.HasIndex(x => x.Date).IsUnique();

            builder.Property(x => x.SellRate)
                .IsRequired()
                .HasColumnType("numeric(9,4)");

            builder.Property(x => x.BuyRate)
                .IsRequired()
                .HasColumnType("numeric(9,4)");

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(250);

            builder.Property(x => x.UpdatedBy)
                .HasMaxLength(250);

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
