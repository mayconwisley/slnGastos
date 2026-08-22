using Gastos.Domain.Common;

namespace Gastos.Application.Clientes;

public sealed record ExcluirClienteCommand(int Id);

public sealed class ExcluirClienteHandler(IClienteRepository clienteRepository)
{
    public async Task<Result> HandleAsync(ExcluirClienteCommand command, CancellationToken cancellationToken)
    {
        var cliente = await clienteRepository.ObterPorIdAsync(command.Id, cancellationToken);
        if (cliente is null)
        {
            return Result.Failure(new Error("cliente.nao_encontrado", "O cliente informado não foi encontrado."));
        }

        await clienteRepository.RemoverAsync(cliente, cancellationToken);
        return Result.Success();
    }
}
