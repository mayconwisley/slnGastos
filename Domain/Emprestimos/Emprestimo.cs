using Gastos.Domain.Common;

namespace Gastos.Domain.Emprestimos;

public sealed class Emprestimo
{
    private Emprestimo()
    {
    }

    private Emprestimo(
        DateOnly dataInicio,
        string descricao,
        decimal valorEmprestado,
        decimal valorParcela,
        int parcelas,
        bool ativo,
        string login,
        int clienteId,
        DateTime dataCadastroUtc)
    {
        DataInicio = dataInicio;
        Descricao = descricao;
        ValorEmprestado = valorEmprestado;
        ValorParcela = valorParcela;
        Parcelas = parcelas;
        Ativo = ativo;
        Login = login;
        ClienteId = clienteId;
        DataCadastroUtc = dataCadastroUtc;
    }

    public int Id { get; private set; }

    public DateOnly DataInicio { get; private set; }

    public string Descricao { get; private set; } = string.Empty;

    public decimal ValorEmprestado { get; private set; }

    public decimal ValorParcela { get; private set; }

    public int Parcelas { get; private set; }

    public bool Ativo { get; private set; }

    public string Login { get; private set; } = string.Empty;

    public int ClienteId { get; private set; }

    public DateTime DataCadastroUtc { get; private set; }

    public decimal ValorTotalParcelas => ValorParcela * Parcelas;

    public static Result<Emprestimo> Criar(
        DateOnly dataInicio,
        string descricao,
        decimal valorEmprestado,
        decimal valorParcela,
        int parcelas,
        bool ativo,
        string login,
        int clienteId,
        DateTime dataCadastroUtc)
    {
        var validacao = Validar(
            descricao,
            valorEmprestado,
            valorParcela,
            parcelas,
            login,
            clienteId);

        if (!validacao.IsSuccess)
        {
            return Result<Emprestimo>.Failure(validacao.Errors.ToArray());
        }

        return Result<Emprestimo>.Success(new Emprestimo(
            dataInicio,
            descricao.Trim(),
            valorEmprestado,
            valorParcela,
            parcelas,
            ativo,
            login.Trim(),
            clienteId,
            dataCadastroUtc));
    }

    public Result Alterar(
        DateOnly dataInicio,
        string descricao,
        decimal valorEmprestado,
        decimal valorParcela,
        int parcelas,
        bool ativo)
    {
        var validacao = Validar(
            descricao,
            valorEmprestado,
            valorParcela,
            parcelas,
            Login,
            ClienteId);

        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        DataInicio = dataInicio;
        Descricao = descricao.Trim();
        ValorEmprestado = valorEmprestado;
        ValorParcela = valorParcela;
        Parcelas = parcelas;
        Ativo = ativo;

        return Result.Success();
    }

    public void Desativar() => Ativo = false;

    private static Result Validar(
        string descricao,
        decimal valorEmprestado,
        decimal valorParcela,
        int parcelas,
        string login,
        int clienteId)
    {
        if (clienteId <= 0)
        {
            return Result.Failure(new Error("emprestimo.cliente.invalido", "O cliente é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(login))
        {
            return Result.Failure(new Error("emprestimo.login.invalido", "O usuário é obrigatório."));
        }

        if (string.IsNullOrWhiteSpace(descricao) || descricao.Trim().Length > 200)
        {
            return Result.Failure(new Error("emprestimo.descricao.invalida", "A descrição deve ter entre 1 e 200 caracteres."));
        }

        if (valorEmprestado <= 0 || valorParcela <= 0)
        {
            return Result.Failure(new Error("emprestimo.valor.invalido", "Os valores devem ser maiores que zero."));
        }

        if (parcelas is < 1 or > 600)
        {
            return Result.Failure(new Error("emprestimo.parcelas.invalida", "A quantidade de parcelas deve estar entre 1 e 600."));
        }

        return Result.Success();
    }
}
