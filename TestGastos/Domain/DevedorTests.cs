using Gastos.Domain.Devedores;

namespace TestGastos.Domain;

public sealed class DevedorTests
{
    [Test]
    public void Criar_ComParcelasInvalidas_DeveRetornarFalha()
    {
        var resultado = Devedor.Criar("João", "Acordo", 100m, 0, new DateOnly(2026, 8, 1), true, "maycon", 1, DateTime.UtcNow);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("devedor.parcelas.invalida"));
    }
}
