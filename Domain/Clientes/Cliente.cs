using Gastos.Domain.Common;

namespace Gastos.Domain.Clientes;

public sealed class Cliente
{
    private Cliente()
    {
    }

    private Cliente(string nome, string login, bool ativo, DateTime dataCadastroUtc)
    {
        Nome = nome;
        Login = login;
        Ativo = ativo;
        DataCadastroUtc = dataCadastroUtc;
    }

    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Login { get; private set; } = string.Empty;

    public bool Ativo { get; private set; }

    public DateTime DataCadastroUtc { get; private set; }

    public static Result<Cliente> Criar(string nome, string login, bool ativo, DateTime dataCadastroUtc)
    {
        var validacao = Validar(nome, login);
        if (!validacao.IsSuccess)
        {
            return Result<Cliente>.Failure(validacao.Errors.ToArray());
        }

        return Result<Cliente>.Success(new Cliente(nome.Trim(), login.Trim(), ativo, dataCadastroUtc));
    }

    public Result Alterar(string nome, bool ativo)
    {
        var validacao = ValidarNome(nome);
        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        Nome = nome.Trim();
        Ativo = ativo;
        return Result.Success();
    }

    private static Result Validar(string nome, string login)
    {
        var nomeResult = ValidarNome(nome);
        if (!nomeResult.IsSuccess)
        {
            return nomeResult;
        }

        if (string.IsNullOrWhiteSpace(login) || login.Trim().Length > 50)
        {
            return Result.Failure(new Error("cliente.login.invalido", "O login do cliente é obrigatório e deve ter no máximo 50 caracteres."));
        }

        return Result.Success();
    }

    private static Result ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length is < 3 or > 120)
        {
            return Result.Failure(new Error("cliente.nome.invalido", "O nome do cliente deve ter entre 3 e 120 caracteres."));
        }

        return Result.Success();
    }
}
