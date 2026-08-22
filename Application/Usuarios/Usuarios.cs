using Gastos.Application.Abstractions;
using Gastos.Application.Seguranca;
using Gastos.Domain.Common;
using Gastos.Domain.Usuarios;

namespace Gastos.Application.Usuarios;

public sealed record UsuarioDto(string Login, string Nome, string Lembrete, bool EstaAtivo, DateTime DataCadastroUtc)
{
    public string Ativo => EstaAtivo ? "Sim" : "Não";
    public DateTime DataCadastro => DataCadastroUtc;
    public string Chave => string.Empty;
    public string Senha => string.Empty;
}

public sealed record CadastrarUsuarioCommand(string Login, string Nome, string Senha, string Lembrete, bool Ativo);
public sealed class CadastrarUsuarioHandler(IUsuarioRepository repository, IPasswordHasher passwordHasher, IClock clock)
{
    public async Task<Result> HandleAsync(CadastrarUsuarioCommand command, CancellationToken ct)
    {
        if (await repository.ObterPorLoginAsync(command.Login.Trim(), ct) is not null)
            return Result.Failure(new Error("usuario.login.duplicado", "Já existe um usuário com esse login."));
        var usuario = Usuario.Criar(command.Login, command.Nome, passwordHasher.GerarHash(command.Senha), command.Lembrete, command.Ativo, clock.UtcNow);
        if (!usuario.IsSuccess || usuario.Value is null) return Result.Failure(usuario.Errors.ToArray());
        await repository.AdicionarAsync(usuario.Value, ct);
        return Result.Success();
    }
}

public sealed record AtualizarUsuarioCommand(string Login, string Nome, string? NovaSenha, string Lembrete, bool Ativo);
public sealed class AtualizarUsuarioHandler(IUsuarioRepository repository, IPasswordHasher passwordHasher)
{
    public async Task<Result> HandleAsync(AtualizarUsuarioCommand command, CancellationToken ct)
    {
        var usuario = await repository.ObterPorLoginAsync(command.Login, ct);
        if (usuario is null) return Result.Failure(new Error("usuario.nao_encontrado", "O usuário informado não foi encontrado."));
        var resultado = usuario.Alterar(command.Nome, command.Lembrete, command.Ativo, string.IsNullOrWhiteSpace(command.NovaSenha) ? null : passwordHasher.GerarHash(command.NovaSenha));
        if (!resultado.IsSuccess) return resultado;
        await repository.AtualizarAsync(usuario, ct);
        return Result.Success();
    }
}

public sealed record ExcluirUsuarioCommand(string Login);
public sealed class ExcluirUsuarioHandler(IUsuarioRepository repository)
{
    public async Task<Result> HandleAsync(ExcluirUsuarioCommand command, CancellationToken ct)
    {
        var usuario = await repository.ObterPorLoginAsync(command.Login, ct);
        if (usuario is null) return Result.Failure(new Error("usuario.nao_encontrado", "O usuário informado não foi encontrado."));
        await repository.RemoverAsync(usuario, ct);
        return Result.Success();
    }
}

public sealed class ListarUsuariosHandler(IUsuarioRepository repository)
{
    public Task<IReadOnlyList<UsuarioDto>> HandleAsync(CancellationToken ct) => repository.ListarAsync(ct);
}

public sealed class QuantidadeUsuariosHandler(IUsuarioRepository repository)
{
    public Task<int> HandleAsync(CancellationToken ct) => repository.ContarAsync(ct);
}

public sealed record AutenticarUsuarioCommand(string Login, string Senha);
public sealed class AutenticarUsuarioHandler(IUsuarioRepository repository, IPasswordHasher passwordHasher, IPasswordCompatibilityVerifier passwordCompatibilityVerifier)
{
    public async Task<Result> HandleAsync(AutenticarUsuarioCommand command, CancellationToken ct)
    {
        var usuario = await repository.ObterPorLoginAsync(command.Login, ct);
        if (usuario is null || !usuario.Ativo) return Result.Failure(new Error("autenticacao.invalida", "Usuário ou senha inválidos."));
        var valido = usuario.SenhaHash.StartsWith("PBKDF2-SHA256$", StringComparison.Ordinal)
            ? passwordHasher.Verificar(command.Senha, usuario.SenhaHash)
            : passwordCompatibilityVerifier.Verificar(command.Senha, usuario.SenhaHash, usuario.ChaveCompatibilidade);
        return valido ? Result.Success() : Result.Failure(new Error("autenticacao.invalida", "Usuário ou senha inválidos."));
    }
}

public sealed record ObterLembreteSenhaQuery(string Login);
public sealed class ObterLembreteSenhaHandler(IUsuarioRepository repository)
{
    public async Task<Result<string>> HandleAsync(ObterLembreteSenhaQuery query, CancellationToken ct)
    {
        var usuario = await repository.ObterPorLoginAsync(query.Login, ct);
        return usuario is null || !usuario.Ativo
            ? Result<string>.Failure(new Error("usuario.nao_encontrado", "Usuário não encontrado ou inativo."))
            : Result<string>.Success(usuario.Lembrete);
    }
}
