using Gastos.Domain.Emprestimos;

namespace Gastos.Application.Emprestimos;

public sealed record EmprestimoDto(
    int Id,
    DateOnly DataInicio,
    string Descricao,
    decimal ValorEmprestado,
    decimal ValorParcela,
    int Parcelas,
    bool Ativo,
    string Login,
    int ClienteId,
    DateTime DataCadastroUtc,
    bool ParcelasGeradas,
    decimal ValorPago)
{
    public decimal ValorAPagar => (ValorParcela * Parcelas) - ValorPago;

    public DateTime DataCadastro => DataCadastroUtc;
}
