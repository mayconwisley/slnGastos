using Gastos.Application.Abstractions;
using Gastos.Domain.Common;
using Gastos.Domain.Clientes;

namespace Gastos.Application.Clientes;

public sealed record CadastrarClienteCommand(string Nome, string Login, bool Ativo);

public sealed class CadastrarClienteHandler(IClienteRepository clienteRepository, IClock clock)
{
    public async Task<Result<int>> HandleAsync(CadastrarClienteCommand command, CancellationToken cancellationToken)
    {
        var clienteResult = Cliente.Criar(command.Nome, command.Login, command.Ativo, clock.UtcNow);
        if (!clienteResult.IsSuccess || clienteResult.Value is null)
        {
            return Result<int>.Failure(clienteResult.Errors.ToArray());
        }

        await clienteRepository.AdicionarAsync(clienteResult.Value, cancellationToken);
        return Result<int>.Success(clienteResult.Value.Id);
    }
}
