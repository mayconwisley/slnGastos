using Gastos.Domain.Devedores;

namespace Gastos.Application.Devedores;

public sealed record DevedorDto(
    int Id,
    string Nome,
    string Descricao,
    decimal Valor,
    int Parcelas,
    DateOnly DataInicio,
    bool Ativo,
    string Login,
    int ClienteId,
    DateTime DataCadastroUtc,
    bool ParcelasGeradas)
{
    public DateTime DataCadastro => DataCadastroUtc;
}

public sealed record ResumoDevedorDto(int DevedoresId, string Nome, decimal Valor, bool EstaRecebido)
{
    public string Recebido => EstaRecebido ? "Sim" : "Não";
}
