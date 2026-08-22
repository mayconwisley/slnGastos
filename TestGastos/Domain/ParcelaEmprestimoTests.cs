using Gastos.Domain.Emprestimos;

namespace TestGastos.Domain;

public sealed class ParcelaEmprestimoTests
{
    [Test]
    public void Alterar_ParcelaQuitadaSemDataDePagamento_DeveRetornarFalha()
    {
        var criacao = ParcelaEmprestimo.Criar(
            emprestimoId: 1,
            dataParcela: new DateOnly(2026, 8, 10),
            numero: 1,
            valor: 100m,
            login: "maycon",
            dataCadastroUtc: DateTime.UtcNow);

        var resultado = criacao.Value!.Alterar(
            dataParcela: new DateOnly(2026, 8, 10),
            numero: 1,
            valor: 100m,
            pago: true,
            dataPagamento: null);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("parcela_emprestimo.pagamento.obrigatorio"));
    }

    [Test]
    public void Alterar_ParcelaQuitadaComPagamentoAnteriorAoVencimento_DeveRetornarFalha()
    {
        var criacao = ParcelaEmprestimo.Criar(1, new DateOnly(2026, 8, 10), 1, 100m, "maycon", DateTime.UtcNow);

        var resultado = criacao.Value!.Alterar(
            new DateOnly(2026, 8, 10),
            1,
            100m,
            pago: true,
            dataPagamento: new DateOnly(2026, 8, 9));

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("parcela_emprestimo.pagamento.anterior"));
    }
}
