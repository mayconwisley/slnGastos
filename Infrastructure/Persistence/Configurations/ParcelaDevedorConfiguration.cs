using Gastos.Domain.Devedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class ParcelaDevedorConfiguration : IEntityTypeConfiguration<ParcelaDevedor>
{
    public void Configure(EntityTypeBuilder<ParcelaDevedor> builder)
    {
        builder.ToTable("MovimentoDevedores");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.DevedorId).HasColumnName("DevedoresId");
        builder.Property(item => item.DataParcela).HasConversion(PersistenceValueConverters.DateOnlyConverter);
        builder.Property(item => item.Valor).HasPrecision(18, 2);
        builder.Property(item => item.Recebido)
            .HasConversion(value => value ? "Sim" : "Não", value => value == "Sim")
            .HasMaxLength(3);
        builder.Property(item => item.DataCadastroUtc).HasColumnName("DataCadastro");
        builder.Property(item => item.DataRecebido).HasConversion(PersistenceValueConverters.NullableDateOnlyConverter);
        builder.HasIndex(item => new { item.DevedorId, item.Parcela }).IsUnique();
    }
}
