using Gastos.Domain.Devedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class DevedorConfiguration : IEntityTypeConfiguration<Devedor>
{
    public void Configure(EntityTypeBuilder<Devedor> builder)
    {
        builder.ToTable("Devedores");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.DataInicio).HasConversion(PersistenceValueConverters.DateOnlyConverter);
        builder.Property(item => item.Nome).HasMaxLength(120).IsRequired();
        builder.Property(item => item.Descricao).HasMaxLength(200).IsRequired();
        builder.Property(item => item.Valor).HasPrecision(18, 2);
        builder.Property(item => item.Ativo)
            .HasConversion(value => value ? "Sim" : "Não", value => value == "Sim")
            .HasMaxLength(3);
        builder.Property(item => item.DataCadastroUtc).HasColumnName("DataCadastro");
        builder.HasIndex(item => new { item.ClienteId, item.Nome });
    }
}
