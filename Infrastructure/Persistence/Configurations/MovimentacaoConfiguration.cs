using Gastos.Domain.Movimentacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal sealed class MovimentacaoConfiguration : IEntityTypeConfiguration<Movimentacao>
{
    public void Configure(EntityTypeBuilder<Movimentacao> builder)
    {
        builder.ToTable("Movimentacao");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.DataMovimento).HasConversion(PersistenceValueConverters.DateOnlyConverter);
        builder.Property(item => item.Descricao).HasMaxLength(200).IsRequired();
        builder.Property(item => item.Valor).HasPrecision(18, 2);
        builder.Property(item => item.TipoLancamento)
            .HasConversion(
                value => value == TipoLancamento.Entrada ? "Entrada" : "Saída",
                value => value == "Entrada" ? TipoLancamento.Entrada : TipoLancamento.Saida)
            .HasMaxLength(10);
        builder.Property(item => item.MeioMonetario)
            .HasColumnName("TipoMonetario")
            .HasConversion(
                value => value == MeioMonetario.Dinheiro ? "Dinheiro" : "Cheque",
                value => value == "Cheque" ? MeioMonetario.Cheque : MeioMonetario.Dinheiro)
            .HasMaxLength(10);
        builder.Property(item => item.Situacao)
            .HasColumnName("TipoPagoRecebido")
            .HasConversion(
                value => value.ToString(),
                value => value == "Pago"
                    ? SituacaoFinanceira.Pago
                    : value == "Recebido"
                        ? SituacaoFinanceira.Recebido
                        : SituacaoFinanceira.Pendente)
            .HasMaxLength(10);
        builder.Property(item => item.Origem)
            .HasColumnName("Integrado")
            .HasConversion(
                value => value == OrigemMovimentacao.Manual
                    ? "Manual"
                    : value == OrigemMovimentacao.IntegradoFixos
                        ? "Integrado Fixos"
                        : value == OrigemMovimentacao.IntegradoEmprestimos
                            ? "Integrado Emprestimos"
                            : "Integrado Devedores",
                value => value == "Integrado Fixos"
                    ? OrigemMovimentacao.IntegradoFixos
                    : value == "Integrado Emprestimos"
                        ? OrigemMovimentacao.IntegradoEmprestimos
                        : value == "Integrado Devedores"
                            ? OrigemMovimentacao.IntegradoDevedores
                            : OrigemMovimentacao.Manual);
        builder.Property(item => item.DataCadastroUtc).HasColumnName("DataCadastro");
        builder.HasIndex(item => new { item.ClienteId, item.CompetenciaId, item.DataMovimento });
    }
}
