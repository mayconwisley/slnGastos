using Gastos.Domain.Devedores;

namespace TestGastos.Domain;

public sealed class ParcelaDevedorTests
{
    [Test]
    public void Alterar_ParcelaRecebidaSemDataDeRecebimento_DeveRetornarFalha()
    {
        var criacao = ParcelaDevedor.Criar(
            devedorId: 1,
            dataParcela: new DateOnly(2026, 8, 10),
            numero: 1,
            valor: 100m,
            login: "maycon",
            dataCadastroUtc: DateTime.UtcNow);

        var resultado = criacao.Value!.Alterar(
            dataParcela: new DateOnly(2026, 8, 10),
            numero: 1,
            valor: 100m,
            recebido: true,
            dataRecebido: null);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("parcela_devedor.recebimento.obrigatorio"));
    }

    [Test]
    public void Alterar_ParcelaEmAbertoComDataDeRecebimento_DeveRetornarFalha()
    {
        var criacao = ParcelaDevedor.Criar(1, new DateOnly(2026, 8, 10), 1, 100m, "maycon", DateTime.UtcNow);

        var resultado = criacao.Value!.Alterar(
            new DateOnly(2026, 8, 10),
            1,
            100m,
            recebido: false,
            dataRecebido: new DateOnly(2026, 8, 10));

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("parcela_devedor.recebimento.invalido"));
    }
}
