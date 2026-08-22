using Gastos.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(item => item.Login);
        builder.Property(item => item.Login).HasMaxLength(50).IsRequired();
        builder.Property(item => item.Nome).HasMaxLength(120).IsRequired();
        builder.Property(item => item.SenhaHash).HasColumnName("Senha").IsRequired();
        builder.Property(item => item.ChaveCompatibilidade).HasColumnName("Chave").IsRequired();
        builder.Property(item => item.Lembrete).HasMaxLength(200).IsRequired();
        builder.Property(item => item.Ativo)
            .HasConversion(value => value ? "Sim" : "Não", value => value == "Sim")
            .HasMaxLength(3)
            .IsRequired();
        builder.Property(item => item.DataCadastroUtc).HasColumnName("DataCadastro").IsRequired();
    }
}
