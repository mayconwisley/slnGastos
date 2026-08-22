using Gastos.Domain.Common;

namespace Gastos.Application.Clientes;

public sealed record AtualizarClienteCommand(int Id, string Nome, bool Ativo);

public sealed class AtualizarClienteHandler(IClienteRepository clienteRepository)
{
    public async Task<Result> HandleAsync(AtualizarClienteCommand command, CancellationToken cancellationToken)
    {
        var cliente = await clienteRepository.ObterPorIdAsync(command.Id, cancellationToken);
        if (cliente is null)
        {
            return Result.Failure(new Error("cliente.nao_encontrado", "O cliente informado não foi encontrado."));
        }

        var alteracao = cliente.Alterar(command.Nome, command.Ativo);
        if (!alteracao.IsSuccess)
        {
            return alteracao;
        }

        await clienteRepository.AtualizarAsync(cliente, cancellationToken);
        return Result.Success();
    }
}
