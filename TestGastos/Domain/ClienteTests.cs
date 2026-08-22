using Gastos.Domain.Clientes;

namespace TestGastos.Domain;

public sealed class ClienteTests
{
    [Test]
    public void Criar_ComNomeInvalido_DeveRetornarFalha()
    {
        var result = Cliente.Criar(" ", "maycon", true, DateTime.UtcNow);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Errors.Single().Code, Is.EqualTo("cliente.nome.invalido"));
    }

    [Test]
    public void Alterar_ComDadosValidos_DeveAtualizarEstadoDaEntidade()
    {
        var clienteResult = Cliente.Criar("Ana Souza", "ana", true, DateTime.UtcNow);
        var cliente = clienteResult.Value!;

        var result = cliente.Alterar("Ana Silva", false);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(cliente.Nome, Is.EqualTo("Ana Silva"));
        Assert.That(cliente.Ativo, Is.False);
    }
}
