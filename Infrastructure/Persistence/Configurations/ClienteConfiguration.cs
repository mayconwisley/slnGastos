using Gastos.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Nome).HasMaxLength(120).IsRequired();
        builder.Property(item => item.Login).HasMaxLength(50).IsRequired();
        builder.Property(item => item.Ativo)
            .HasConversion(value => value ? "Sim" : "Não", value => value == "Sim")
            .HasMaxLength(3)
            .IsRequired();
        builder.Property(item => item.DataCadastroUtc).HasColumnName("Data").IsRequired();
        builder.HasIndex(item => item.Nome);
        builder.HasIndex(item => item.Login);
    }
}
