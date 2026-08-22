using Gastos.Infrastructure.Seguranca;

namespace TestGastos.Infrastructure;

public sealed class Pbkdf2PasswordHasherTests
{
    [Test]
    public void GerarHash_QuandoSenhaValida_DevePermitirVerificacaoSemExporSenha()
    {
        var hasher = new Pbkdf2PasswordHasher();
        var hash = hasher.GerarHash("SenhaForte#2026");

        Assert.That(hash, Does.Not.Contain("SenhaForte#2026"));
        Assert.That(hasher.Verificar("SenhaForte#2026", hash), Is.True);
        Assert.That(hasher.Verificar("senha-incorreta", hash), Is.False);
    }
}
