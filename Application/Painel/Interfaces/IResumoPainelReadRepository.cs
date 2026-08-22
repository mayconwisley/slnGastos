namespace Gastos.Application.Painel;

public interface IResumoPainelReadRepository
{
    Task<ResumoPainelDto?> ObterAsync(
        int clienteId,
        DateOnly mesReferencia,
        CancellationToken cancellationToken);
}
