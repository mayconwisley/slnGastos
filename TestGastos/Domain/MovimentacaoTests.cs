using Gastos.Domain.Movimentacoes;

namespace TestGastos.Domain;

public sealed class MovimentacaoTests
{
    [Test]
    public void Criar_SaidaMarcadaComoRecebida_DeveRetornarFalha()
    {
        var resultado = Movimentacao.Criar(new DateOnly(2026, 8, 1), "Conta", 100m, TipoLancamento.Saida, MeioMonetario.Dinheiro, SituacaoFinanceira.Recebido, OrigemMovimentacao.Manual, "maycon", 1, 1, DateTime.UtcNow);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("movimentacao.situacao.invalida"));
    }
}
