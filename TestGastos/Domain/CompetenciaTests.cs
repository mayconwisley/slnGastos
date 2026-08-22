using Gastos.Domain.Competencias;

namespace TestGastos.Domain;

public sealed class CompetenciaTests
{
    [Test]
    public void Criar_ComClienteInvalido_DeveRetornarFalha()
    {
        var resultado = Competencia.Criar(new DateOnly(2026, 8, 1), 0, true);

        Assert.That(resultado.IsSuccess, Is.False);
        Assert.That(resultado.Errors.Single().Code, Is.EqualTo("competencia.cliente.invalido"));
    }

    [Test]
    public void Criar_ComDiaDiferenteDoPrimeiro_DeveNormalizarMesReferencia()
    {
        var resultado = Competencia.Criar(new DateOnly(2026, 8, 21), 1, true);

        Assert.That(resultado.IsSuccess, Is.True);
        Assert.That(resultado.Value!.MesReferencia, Is.EqualTo(new DateOnly(2026, 8, 1)));
    }
}
