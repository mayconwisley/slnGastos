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

public interface IDevedorRepository
{
    Task AdicionarAsync(Devedor devedor, CancellationToken ct);
    Task<Devedor?> ObterPorIdAsync(int id, CancellationToken ct);
    Task AtualizarAsync(Devedor devedor, CancellationToken ct);
    Task RemoverAsync(Devedor devedor, CancellationToken ct);
    Task<bool> PossuiParcelasAsync(int devedorId, CancellationToken ct);
    Task GerarParcelasAsync(Devedor devedor, CancellationToken ct);
}

public interface IDevedorReadRepository
{
    Task<IReadOnlyList<DevedorDto>> ListarPorClienteAsync(int clienteId, CancellationToken ct);
    Task<IReadOnlyList<ResumoDevedorDto>> ListarResumoPorClienteAsync(int clienteId, CancellationToken ct);
}

public sealed record ResumoDevedorDto(int DevedoresId, string Nome, decimal Valor, bool EstaRecebido)
{
    public string Recebido => EstaRecebido ? "Sim" : "Não";
}
