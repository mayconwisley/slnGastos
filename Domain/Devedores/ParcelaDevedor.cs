using Gastos.Domain.Common;

namespace Gastos.Domain.Devedores;

public sealed class ParcelaDevedor
{
    private ParcelaDevedor()
    {
    }

    public ParcelaDevedor(int devedorId, DateOnly dataParcela, int numero, decimal valor, string login, DateTime dataCadastroUtc)
    {
        DevedorId = devedorId;
        DataParcela = dataParcela;
        Parcela = numero;
        Valor = valor;
        Login = login;
        DataCadastroUtc = dataCadastroUtc;
    }

    public int Id { get; private set; }
    public int DevedorId { get; private set; }
    public DateOnly DataParcela { get; private set; }
    public int Parcela { get; private set; }
    public decimal Valor { get; private set; }
    public bool Recebido { get; private set; }
    public string Login { get; private set; } = string.Empty;
    public DateTime DataCadastroUtc { get; private set; }
    public DateOnly? DataRecebido { get; private set; }

    public static Result<ParcelaDevedor> Criar(int devedorId, DateOnly dataParcela, int numero, decimal valor, string login, DateTime dataCadastroUtc)
    {
        if (devedorId <= 0 || string.IsNullOrWhiteSpace(login))
        {
            return Result<ParcelaDevedor>.Failure(new Error("parcela_devedor.referencia.invalida", "Devedor e usuário são obrigatórios."));
        }

        var validacao = Validar(dataParcela, numero, valor, false, null);
        return validacao.IsSuccess
            ? Result<ParcelaDevedor>.Success(new ParcelaDevedor(devedorId, dataParcela, numero, valor, login.Trim(), dataCadastroUtc))
            : Result<ParcelaDevedor>.Failure(validacao.Errors.ToArray());
    }

    public Result Alterar(DateOnly dataParcela, int numero, decimal valor, bool recebido, DateOnly? dataRecebido)
    {
        var validacao = Validar(dataParcela, numero, valor, recebido, dataRecebido);
        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        DataParcela = dataParcela;
        Parcela = numero;
        Valor = valor;
        Recebido = recebido;
        DataRecebido = dataRecebido;
        return Result.Success();
    }

    public Result RegistrarRecebimento(DateOnly dataRecebido)
    {
        Recebido = true;
        DataRecebido = dataRecebido;
        return Result.Success();
    }

    private static Result Validar(DateOnly dataParcela, int numero, decimal valor, bool recebido, DateOnly? dataRecebido)
    {
        if (numero is < 1 or > 600)
        {
            return Result.Failure(new Error("parcela_devedor.numero.invalido", "O número da parcela deve estar entre 1 e 600."));
        }

        if (valor <= 0)
        {
            return Result.Failure(new Error("parcela_devedor.valor.invalido", "O valor da parcela deve ser maior que zero."));
        }

        if (recebido && dataRecebido is null)
        {
            return Result.Failure(new Error("parcela_devedor.recebimento.obrigatorio", "Informe a data de recebimento da parcela."));
        }

        if (!recebido && dataRecebido is not null)
        {
            return Result.Failure(new Error("parcela_devedor.recebimento.invalido", "Uma parcela em aberto não pode ter data de recebimento."));
        }

        if (dataRecebido is not null && dataRecebido < dataParcela)
        {
            return Result.Failure(new Error("parcela_devedor.recebimento.anterior", "A data de recebimento não pode ser anterior ao vencimento."));
        }

        return Result.Success();
    }
}
