using Gastos.Domain.Common;

namespace Gastos.Domain.Movimentacoes;

public sealed class Movimentacao
{
    private Movimentacao()
    {
    }

    private Movimentacao(
        DateOnly dataMovimento,
        string descricao,
        decimal valor,
        TipoLancamento tipoLancamento,
        MeioMonetario meioMonetario,
        SituacaoFinanceira situacao,
        OrigemMovimentacao origem,
        string login,
        int clienteId,
        int competenciaId,
        DateTime dataCadastroUtc)
    {
        DataMovimento = dataMovimento;
        Descricao = descricao;
        Valor = valor;
        TipoLancamento = tipoLancamento;
        MeioMonetario = meioMonetario;
        Situacao = situacao;
        Origem = origem;
        Login = login;
        ClienteId = clienteId;
        CompetenciaId = competenciaId;
        DataCadastroUtc = dataCadastroUtc;
    }

    public int Id { get; private set; }

    public DateOnly DataMovimento { get; private set; }

    public string Descricao { get; private set; } = string.Empty;

    public decimal Valor { get; private set; }

    public TipoLancamento TipoLancamento { get; private set; }

    public MeioMonetario MeioMonetario { get; private set; }

    public SituacaoFinanceira Situacao { get; private set; }

    public OrigemMovimentacao Origem { get; private set; }

    public string Login { get; private set; } = string.Empty;

    public int ClienteId { get; private set; }

    public int CompetenciaId { get; private set; }

    public DateTime DataCadastroUtc { get; private set; }

    public static Result<Movimentacao> Criar(
        DateOnly dataMovimento,
        string descricao,
        decimal valor,
        TipoLancamento tipoLancamento,
        MeioMonetario meioMonetario,
        SituacaoFinanceira situacao,
        OrigemMovimentacao origem,
        string login,
        int clienteId,
        int competenciaId,
        DateTime dataCadastroUtc)
    {
        var validacao = Validar(descricao, valor, tipoLancamento, situacao, login, clienteId, competenciaId);

        if (!validacao.IsSuccess)
        {
            return Result<Movimentacao>.Failure(validacao.Errors.ToArray());
        }

        return Result<Movimentacao>.Success(new Movimentacao(
            dataMovimento,
            descricao.Trim(),
            valor,
            tipoLancamento,
            meioMonetario,
            situacao,
            origem,
            login.Trim(),
            clienteId,
            competenciaId,
            dataCadastroUtc));
    }

    public Result Alterar(
        DateOnly dataMovimento,
        string descricao,
        decimal valor,
        TipoLancamento tipoLancamento,
        MeioMonetario meioMonetario,
        SituacaoFinanceira situacao)
    {
        var validacao = Validar(descricao, valor, tipoLancamento, situacao, Login, ClienteId, CompetenciaId);

        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        DataMovimento = dataMovimento;
        Descricao = descricao.Trim();
        Valor = valor;
        TipoLancamento = tipoLancamento;
        MeioMonetario = meioMonetario;
        Situacao = situacao;

        return Result.Success();
    }

    private static Result Validar(
        string descricao,
        decimal valor,
        TipoLancamento tipoLancamento,
        SituacaoFinanceira situacao,
        string login,
        int clienteId,
        int competenciaId)
    {
        if (string.IsNullOrWhiteSpace(descricao) || descricao.Trim().Length > 200)
        {
            return Result.Failure(new Error("movimentacao.descricao.invalida", "A descrição deve ter entre 1 e 200 caracteres."));
        }

        if (valor <= 0)
        {
            return Result.Failure(new Error("movimentacao.valor.invalido", "O valor deve ser maior que zero."));
        }

        if (string.IsNullOrWhiteSpace(login) || clienteId <= 0 || competenciaId <= 0)
        {
            return Result.Failure(new Error("movimentacao.referencia.invalida", "Cliente, competência e usuário são obrigatórios."));
        }

        var situacaoIncompativel =
            (tipoLancamento == TipoLancamento.Entrada && situacao == SituacaoFinanceira.Pago) ||
            (tipoLancamento == TipoLancamento.Saida && situacao == SituacaoFinanceira.Recebido);

        return situacaoIncompativel
            ? Result.Failure(new Error("movimentacao.situacao.invalida", "A situação não é compatível com o tipo de lançamento."))
            : Result.Success();
    }
}
