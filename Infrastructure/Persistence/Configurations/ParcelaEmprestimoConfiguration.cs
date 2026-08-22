using Gastos.Domain.Emprestimos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class ParcelaEmprestimoConfiguration : IEntityTypeConfiguration<ParcelaEmprestimo>
{
    public void Configure(EntityTypeBuilder<ParcelaEmprestimo> builder)
    {
        builder.ToTable("MovimentoEmprestimos");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.EmprestimoId).HasColumnName("EmprestimosId");
        builder.Property(item => item.DataParcela).HasConversion(PersistenceValueConverters.DateOnlyConverter);
        builder.Property(item => item.Valor).HasPrecision(18, 2);
        builder.Property(item => item.Pago)
            .HasConversion(value => value ? "Sim" : "Não", value => value == "Sim")
            .HasMaxLength(3);
        builder.Property(item => item.DataCadastroUtc).HasColumnName("DataCadastro");
        builder.Property(item => item.DataPagamento).HasConversion(PersistenceValueConverters.NullableDateOnlyConverter);
        builder.HasIndex(item => new { item.EmprestimoId, item.Parcela }).IsUnique();
    }
}
