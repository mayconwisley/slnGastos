using Gastos.Domain.Common;

namespace Gastos.Domain.Competencias;

public sealed class Competencia
{
    private Competencia()
    {
    }

    private Competencia(DateOnly mesReferencia, int clienteId, bool ativa)
    {
        MesReferencia = mesReferencia;
        ClienteId = clienteId;
        Ativa = ativa;
    }

    public int Id { get; private set; }

    public DateOnly MesReferencia { get; private set; }

    public int ClienteId { get; private set; }

    public bool Ativa { get; private set; }

    public static Result<Competencia> Criar(DateOnly mesReferencia, int clienteId, bool ativa)
    {
        var validacao = Validar(mesReferencia, clienteId);
        if (!validacao.IsSuccess)
        {
            return Result<Competencia>.Failure(validacao.Errors.ToArray());
        }

        return Result<Competencia>.Success(new Competencia(PrimeiroDiaDoMes(mesReferencia), clienteId, ativa));
    }

    public Result Alterar(DateOnly mesReferencia, bool ativa)
    {
        var validacao = Validar(mesReferencia, ClienteId);
        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        MesReferencia = PrimeiroDiaDoMes(mesReferencia);
        Ativa = ativa;
        return Result.Success();
    }

    public void Desativar() => Ativa = false;

    private static Result Validar(DateOnly mesReferencia, int clienteId)
    {
        if (clienteId <= 0)
        {
            return Result.Failure(new Error("competencia.cliente.invalido", "O cliente da competência é obrigatório."));
        }

        if (mesReferencia.Year is < 2000 or > 2100)
        {
            return Result.Failure(new Error("competencia.mes.invalido", "O mês da competência deve estar entre os anos de 2000 e 2100."));
        }

        return Result.Success();
    }

    private static DateOnly PrimeiroDiaDoMes(DateOnly data) => new(data.Year, data.Month, 1);
}
