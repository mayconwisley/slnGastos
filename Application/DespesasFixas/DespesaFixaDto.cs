namespace Gastos.Application.DespesasFixas;
public sealed record DespesaFixaDto(int Id, DateOnly DataInicio, string Descricao, decimal Valor, DateOnly? DataFim, bool Ativa, string Login, int ClienteId, DateTime DataCadastroUtc)
{
    public string Ativo => Ativa ? "Sim" : "Não";
    public string Integrar => "Não";
    public DateTime DataCadastro => DataCadastroUtc;
}
