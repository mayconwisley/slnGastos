using Gastos.Domain.Movimentacoes;

namespace Gastos.Application.Movimentacoes;

public sealed record MovimentacaoDto(
    int Id,
    DateOnly DataMovimento,
    string Descricao,
    decimal Valor,
    TipoLancamento TipoLancamento,
    MeioMonetario MeioMonetario,
    SituacaoFinanceira Situacao,
    OrigemMovimentacao Origem,
    string Login,
    int ClienteId,
    int CompetenciaId,
    DateTime DataCadastroUtc)
{
    public string TipoMonetario => MeioMonetario == MeioMonetario.Cheque ? "Cheque" : "Dinheiro";
    public string TipoPagoRecebido => Situacao.ToString();
    public string Integrado => Origem switch
    {
        OrigemMovimentacao.IntegradoFixos => "Integrado Fixos",
        OrigemMovimentacao.IntegradoEmprestimos => "Integrado Emprestimos",
        OrigemMovimentacao.IntegradoDevedores => "Integrado Devedores",
        _ => "Manual"
    };
    public DateTime DataCadastro => DataCadastroUtc;
}
public interface IMovimentacaoRepository{Task AdicionarAsync(Movimentacao movimentacao,CancellationToken ct);Task<Movimentacao?>ObterPorIdAsync(int id,CancellationToken ct);Task AtualizarAsync(Movimentacao movimentacao,CancellationToken ct);Task RemoverAsync(Movimentacao movimentacao,CancellationToken ct);}
public interface IMovimentacaoReadRepository{Task<IReadOnlyList<MovimentacaoDto>>ListarPorCompetenciaAsync(int clienteId,int competenciaId,CancellationToken ct);}
