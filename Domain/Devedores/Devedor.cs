using Gastos.Domain.Common;

namespace Gastos.Domain.Devedores;

public sealed class Devedor
{
    private Devedor()
    {
    }

    private Devedor(
        string nome,
        string descricao,
        decimal valor,
        int parcelas,
        DateOnly dataInicio,
        bool ativo,
        string login,
        int clienteId,
        DateTime dataCadastroUtc)
    {
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Parcelas = parcelas;
        DataInicio = dataInicio;
        Ativo = ativo;
        Login = login;
        ClienteId = clienteId;
        DataCadastroUtc = dataCadastroUtc;
    }

    public int Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Descricao { get; private set; } = string.Empty;

    public decimal Valor { get; private set; }

    public int Parcelas { get; private set; }

    public DateOnly DataInicio { get; private set; }

    public bool Ativo { get; private set; }

    public string Login { get; private set; } = string.Empty;

    public int ClienteId { get; private set; }

    public DateTime DataCadastroUtc { get; private set; }

    public static Result<Devedor> Criar(
        string nome,
        string descricao,
        decimal valor,
        int parcelas,
        DateOnly dataInicio,
        bool ativo,
        string login,
        int clienteId,
        DateTime dataCadastroUtc)
    {
        var validacao = Validar(nome, descricao, valor, parcelas, login, clienteId);

        if (!validacao.IsSuccess)
        {
            return Result<Devedor>.Failure(validacao.Errors.ToArray());
        }

        return Result<Devedor>.Success(new Devedor(
            nome.Trim(),
            descricao.Trim(),
            valor,
            parcelas,
            dataInicio,
            ativo,
            login.Trim(),
            clienteId,
            dataCadastroUtc));
    }

    public Result Alterar(
        string nome,
        string descricao,
        decimal valor,
        int parcelas,
        DateOnly dataInicio,
        bool ativo)
    {
        var validacao = Validar(nome, descricao, valor, parcelas, Login, ClienteId);

        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        Nome = nome.Trim();
        Descricao = descricao.Trim();
        Valor = valor;
        Parcelas = parcelas;
        DataInicio = dataInicio;
        Ativo = ativo;

        return Result.Success();
    }

    private static Result Validar(
        string nome,
        string descricao,
        decimal valor,
        int parcelas,
        string login,
        int clienteId)
    {
        if (clienteId <= 0)
        {
            return Result.Failure(new Error("devedor.cliente.invalido", "O cliente é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length > 120)
        {
            return Result.Failure(new Error("devedor.nome.invalido", "O nome deve ter entre 1 e 120 caracteres."));
        }

        if (string.IsNullOrWhiteSpace(descricao) || descricao.Trim().Length > 200)
        {
            return Result.Failure(new Error("devedor.descricao.invalida", "A descrição é obrigatória."));
        }

        if (valor <= 0)
        {
            return Result.Failure(new Error("devedor.valor.invalido", "O valor deve ser maior que zero."));
        }

        if (parcelas is < 1 or > 600)
        {
            return Result.Failure(new Error("devedor.parcelas.invalida", "A quantidade de parcelas deve estar entre 1 e 600."));
        }

        if (string.IsNullOrWhiteSpace(login))
        {
            return Result.Failure(new Error("devedor.login.invalido", "O usuário é obrigatório."));
        }

        return Result.Success();
    }
}
