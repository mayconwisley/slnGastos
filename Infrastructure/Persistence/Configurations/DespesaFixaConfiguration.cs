using Gastos.Domain.DespesasFixas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class DespesaFixaConfiguration : IEntityTypeConfiguration<DespesaFixa>
{
    public void Configure(EntityTypeBuilder<DespesaFixa> builder)
    {
        builder.ToTable("Fixos");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.DataInicio)
            .HasConversion(PersistenceValueConverters.DateOnlyConverter)
            .IsRequired();
        builder.Property(item => item.Descricao).HasMaxLength(200).IsRequired();
        builder.Property(item => item.Valor).HasPrecision(18, 2).IsRequired();
        builder.Property(item => item.DataFim).HasConversion(PersistenceValueConverters.NullableDateOnlyConverter);
        builder.Property(item => item.Login).HasMaxLength(50).IsRequired();
        builder.Property(item => item.ClienteId).IsRequired();
        builder.Property(item => item.DataCadastroUtc).HasColumnName("DataCadastro").IsRequired();
        builder.Ignore(item => item.Ativa);
        builder.HasIndex(item => new { item.ClienteId, item.DataInicio });
    }
}
