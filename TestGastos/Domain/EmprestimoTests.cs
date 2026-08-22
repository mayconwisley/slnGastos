using Gastos.Domain.Emprestimos;

namespace TestGastos.Domain;

public sealed class EmprestimoTests
{
    [Test]
    public void Criar_ComValorDaParcelaInvalido_DeveRetornarFalha()
    {
        var resultado = Emprestimo.Criar(new DateOnly(2026, 8, 1), "Empréstimo", 1000m, 0m, 10, true, "maycon", 1, DateTime.UtcNow);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("emprestimo.valor.invalido"));
    }

    [Test]
    public void Criar_ComDadosValidos_DeveCalcularTotalDasParcelas()
    {
        var resultado = Emprestimo.Criar(new DateOnly(2026, 8, 1), "Veículo", 10000m, 1000m, 10, true, "maycon", 1, DateTime.UtcNow);

        Assert.That(resultado.IsSuccess, Is.True);
        Assert.That(resultado.Value!.ValorTotalParcelas, Is.EqualTo(10000m));
    }
}
