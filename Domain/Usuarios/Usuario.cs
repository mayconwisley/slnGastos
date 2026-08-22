using Gastos.Domain.Common;

namespace Gastos.Domain.Usuarios;

public sealed class Usuario
{
    private Usuario()
    {
    }

    private Usuario(string login, string nome, string senhaHash, string lembrete, bool ativo, DateTime dataCadastroUtc)
    {
        Login = login;
        Nome = nome;
        SenhaHash = senhaHash;
        Lembrete = lembrete;
        Ativo = ativo;
        DataCadastroUtc = dataCadastroUtc;
    }

    public string Login { get; private set; } = string.Empty;
    public string Nome { get; private set; } = string.Empty;
    public string SenhaHash { get; private set; } = string.Empty;
    public string ChaveCompatibilidade { get; private set; } = string.Empty;
    public string Lembrete { get; private set; } = string.Empty;
    public bool Ativo { get; private set; }
    public DateTime DataCadastroUtc { get; private set; }

    public static Result<Usuario> Criar(string login, string nome, string senhaHash, string lembrete, bool ativo, DateTime dataCadastroUtc)
    {
        var validacao = Validar(login, nome, senhaHash, lembrete);
        return validacao.IsSuccess
            ? Result<Usuario>.Success(new Usuario(login.Trim(), nome.Trim(), senhaHash, lembrete.Trim(), ativo, dataCadastroUtc))
            : Result<Usuario>.Failure(validacao.Errors.ToArray());
    }

    public Result Alterar(string nome, string lembrete, bool ativo, string? novaSenhaHash)
    {
        var validacao = Validar(Login, nome, novaSenhaHash ?? SenhaHash, lembrete);
        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        Nome = nome.Trim();
        Lembrete = lembrete.Trim();
        Ativo = ativo;
        if (!string.IsNullOrWhiteSpace(novaSenhaHash))
        {
            SenhaHash = novaSenhaHash;
            ChaveCompatibilidade = string.Empty;
        }
        return Result.Success();
    }

    private static Result Validar(string login, string nome, string senhaHash, string lembrete)
    {
        if (string.IsNullOrWhiteSpace(login) || login.Trim().Length > 50)
            return Result.Failure(new Error("usuario.login.invalido", "O login é obrigatório e deve ter no máximo 50 caracteres."));
        if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length > 120)
            return Result.Failure(new Error("usuario.nome.invalido", "O nome é obrigatório e deve ter no máximo 120 caracteres."));
        if (string.IsNullOrWhiteSpace(senhaHash))
            return Result.Failure(new Error("usuario.senha.invalida", "A senha é obrigatória."));
        if (lembrete?.Length > 200)
            return Result.Failure(new Error("usuario.lembrete.invalido", "O lembrete deve ter no máximo 200 caracteres."));
        return Result.Success();
    }
}
