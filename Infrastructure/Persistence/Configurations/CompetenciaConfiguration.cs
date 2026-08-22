using Gastos.Domain.Competencias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class CompetenciaConfiguration : IEntityTypeConfiguration<Competencia>
{
    public void Configure(EntityTypeBuilder<Competencia> builder)
    {
        builder.ToTable("Competencia");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.MesReferencia)
            .HasColumnName("Data")
            .HasConversion(PersistenceValueConverters.DateOnlyConverter)
            .IsRequired();
        builder.Property(item => item.ClienteId).IsRequired();
        builder.Property(item => item.Ativa)
            .HasColumnName("Ativo")
            .HasConversion(value => value ? "Sim" : "Não", value => value == "Sim")
            .HasMaxLength(3)
            .IsRequired();
        builder.HasIndex(item => new { item.ClienteId, item.MesReferencia });
        builder.HasIndex(item => new { item.ClienteId, item.Ativa });
    }
}
