using Gastos.Domain.DespesasFixas;

namespace TestGastos.Domain;

public sealed class DespesaFixaTests
{
    [Test]
    public void Criar_ComDataFimAnteriorAoInicio_DeveRetornarFalha()
    {
        var resultado = DespesaFixa.Criar(
            new DateOnly(2026, 8, 1),
            "Aluguel",
            1500m,
            new DateOnly(2026, 7, 31),
            "maycon",
            1,
            DateTime.UtcNow);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("despesa_fixa.periodo.invalido"));
    }

    [Test]
    public void Criar_SemDataFim_DeveManterDespesaAtiva()
    {
        var resultado = DespesaFixa.Criar(new DateOnly(2026, 8, 1), "Internet", 120m, null, "maycon", 1, DateTime.UtcNow);

        Assert.That(resultado.IsSuccess, Is.True);
        Assert.That(resultado.Value!.Ativa, Is.True);
    }
}
