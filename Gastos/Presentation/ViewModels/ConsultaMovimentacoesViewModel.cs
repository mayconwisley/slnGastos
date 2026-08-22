using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.Movimentacoes;

namespace Gastos.Presentation.ViewModels;

public sealed class ConsultaMovimentacoesViewModel : ConsultaPorClienteViewModel<MovimentacaoDto>
{
    private readonly ListarCompetenciasPorClienteHandler listarCompetenciasHandler;
    private readonly ListarMovimentacoesPorCompetenciaHandler listarMovimentacoesHandler;
    private CompetenciaDto? competenciaAtiva;

    public ConsultaMovimentacoesViewModel(
        ListarClientesHandler listarClientesHandler,
        ListarCompetenciasPorClienteHandler listarCompetenciasHandler,
        ListarMovimentacoesPorCompetenciaHandler listarMovimentacoesHandler)
        : base(listarClientesHandler)
    {
        this.listarCompetenciasHandler = listarCompetenciasHandler;
        this.listarMovimentacoesHandler = listarMovimentacoesHandler;
    }

    public string CompetenciaAtual => competenciaAtiva is null
        ? "Nenhuma competência ativa"
        : competenciaAtiva.MesReferencia.ToString("MM/yyyy");

    protected override async Task<IEnumerable<MovimentacaoDto>> ListarItensAsync(int clienteId, CancellationToken cancellationToken)
    {
        competenciaAtiva = null;
        OnPropertyChanged(nameof(CompetenciaAtual));

        var competencias = await listarCompetenciasHandler.HandleAsync(
            new ListarCompetenciasPorClienteQuery(clienteId),
            cancellationToken);

        competenciaAtiva = competencias.FirstOrDefault(item => item.Ativa);
        OnPropertyChanged(nameof(CompetenciaAtual));

        if (competenciaAtiva is null)
        {
            DefinirStatus("O cliente não possui competência ativa.");
            return [];
        }

        return await listarMovimentacoesHandler.HandleAsync(
            new ListarMovimentacoesPorCompetenciaQuery(clienteId, competenciaAtiva.Id),
            cancellationToken);
    }
}
