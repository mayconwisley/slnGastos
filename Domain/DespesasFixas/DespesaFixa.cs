using Gastos.Domain.Common;

namespace Gastos.Domain.DespesasFixas;

public sealed class DespesaFixa
{
    private DespesaFixa()
    {
    }

    private DespesaFixa(DateOnly dataInicio, string descricao, decimal valor, DateOnly? dataFim, string login, int clienteId, DateTime dataCadastroUtc)
    {
        DataInicio = dataInicio;
        Descricao = descricao;
        Valor = valor;
        DataFim = dataFim;
        Login = login;
        ClienteId = clienteId;
        DataCadastroUtc = dataCadastroUtc;
    }

    public int Id { get; private set; }
    public DateOnly DataInicio { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public decimal Valor { get; private set; }
    public DateOnly? DataFim { get; private set; }
    public string Login { get; private set; } = string.Empty;
    public int ClienteId { get; private set; }
    public DateTime DataCadastroUtc { get; private set; }
    public bool Ativa => DataFim is null;

    public static Result<DespesaFixa> Criar(DateOnly inicio, string descricao, decimal valor, DateOnly? fim, string login, int clienteId, DateTime cadastroUtc)
    {
        var validacao = Validar(inicio, descricao, valor, fim, login, clienteId);
        return !validacao.IsSuccess
            ? Result<DespesaFixa>.Failure(validacao.Errors.ToArray())
            : Result<DespesaFixa>.Success(new DespesaFixa(inicio, descricao.Trim(), valor, fim, login.Trim(), clienteId, cadastroUtc));
    }

    public Result Alterar(DateOnly inicio, string descricao, decimal valor, DateOnly? fim)
    {
        var validacao = Validar(inicio, descricao, valor, fim, Login, ClienteId);
        if (!validacao.IsSuccess) return validacao;
        DataInicio = inicio; Descricao = descricao.Trim(); Valor = valor; DataFim = fim;
        return Result.Success();
    }

    private static Result Validar(DateOnly inicio, string descricao, decimal valor, DateOnly? fim, string login, int clienteId)
    {
        if (clienteId <= 0) return Result.Failure(new Error("despesa_fixa.cliente.invalido", "O cliente é obrigatório."));
        if (string.IsNullOrWhiteSpace(login) || login.Trim().Length > 50) return Result.Failure(new Error("despesa_fixa.login.invalido", "O usuário é obrigatório."));
        if (string.IsNullOrWhiteSpace(descricao) || descricao.Trim().Length > 200) return Result.Failure(new Error("despesa_fixa.descricao.invalida", "A descrição deve ter entre 1 e 200 caracteres."));
        if (valor <= 0) return Result.Failure(new Error("despesa_fixa.valor.invalido", "O valor deve ser maior que zero."));
        if (fim is not null && fim < inicio) return Result.Failure(new Error("despesa_fixa.periodo.invalido", "A data final não pode ser anterior à data inicial."));
        return Result.Success();
    }
}
