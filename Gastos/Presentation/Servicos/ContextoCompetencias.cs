using System.Globalization;
using Gastos.Application.Competencias;
using Gastos.Presentation.ViewModels;

namespace Gastos.Presentation.Servicos;

public sealed class ContextoCompetencias(ListarCompetenciasAtivasHandler listarCompetenciasAtivasHandler) : ObservableObject
{
    private string descricao = "Nenhuma competência ativa";

    public string Descricao
    {
        get => descricao;
        private set => SetProperty(ref descricao, value);
    }

    public async Task AtualizarAsync(CancellationToken cancellationToken)
    {
        var competencias = await listarCompetenciasAtivasHandler.HandleAsync(
            new ListarCompetenciasAtivasQuery(),
            cancellationToken);

        Descricao = competencias.Count == 0
            ? "Nenhuma competência ativa"
            : string.Join(
                "  |  ",
                competencias.Select(item =>
                    $"{item.ClienteNome} · {item.MesReferencia.ToString("MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"))}"));
    }

    public void IndicarFalha() => Descricao = "Não foi possível carregar as competências ativas";
}
