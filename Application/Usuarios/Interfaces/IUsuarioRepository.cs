using Gastos.Domain.Usuarios;

namespace Gastos.Application.Usuarios;

public interface IUsuarioRepository
{
    Task AdicionarAsync(Usuario usuario, CancellationToken cancellationToken);

    Task<Usuario?> ObterPorLoginAsync(string login, CancellationToken cancellationToken);

    Task AtualizarAsync(Usuario usuario, CancellationToken cancellationToken);

    Task RemoverAsync(Usuario usuario, CancellationToken cancellationToken);

    Task<IReadOnlyList<UsuarioDto>> ListarAsync(CancellationToken cancellationToken);

    Task<int> ContarAsync(CancellationToken cancellationToken);
}
