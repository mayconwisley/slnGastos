using Gastos.Domain.Emprestimos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        builder.ToTable("Emprestimos");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.DataInicio).HasConversion(PersistenceValueConverters.DateOnlyConverter);
        builder.Property(item => item.Descricao).HasMaxLength(200).IsRequired();
        builder.Property(item => item.ValorEmprestado).HasPrecision(18, 2);
        builder.Property(item => item.ValorParcela).HasPrecision(18, 2);
        builder.Property(item => item.Ativo)
            .HasConversion(value => value ? "Sim" : "Não", value => value == "Sim")
            .HasMaxLength(3);
        builder.Property(item => item.DataCadastroUtc).HasColumnName("DataCadastro");
        builder.HasIndex(item => new { item.ClienteId, item.DataInicio });
    }
}
