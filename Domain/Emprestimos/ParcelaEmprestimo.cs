using Gastos.Domain.Common;

namespace Gastos.Domain.Emprestimos;

public sealed class ParcelaEmprestimo
{
    private ParcelaEmprestimo() { }
    public ParcelaEmprestimo(int emprestimoId, DateOnly vencimento, int numero, decimal valor, string login, DateTime cadastroUtc)
    {
        EmprestimoId = emprestimoId;
        DataParcela = vencimento;
        Parcela = numero;
        Valor = valor;
        Login = login;
        DataCadastroUtc = cadastroUtc;
    }
    public int Id { get; private set; }
    public int EmprestimoId { get; private set; }
    public DateOnly DataParcela { get; private set; }
    public int Parcela { get; private set; }
    public decimal Valor { get; private set; }
    public bool Pago { get; private set; }
    public string Login { get; private set; } = string.Empty;
    public DateTime DataCadastroUtc { get; private set; }
    public DateOnly? DataPagamento { get; private set; }

    public static Result<ParcelaEmprestimo> Criar(int emprestimoId, DateOnly dataParcela, int numero, decimal valor, string login, DateTime dataCadastroUtc)
    {
        if (emprestimoId <= 0 || string.IsNullOrWhiteSpace(login))
        {
            return Result<ParcelaEmprestimo>.Failure(new Error("parcela_emprestimo.referencia.invalida", "Empréstimo e usuário são obrigatórios."));
        }

        var validacao = Validar(dataParcela, numero, valor, false, null);
        return validacao.IsSuccess
            ? Result<ParcelaEmprestimo>.Success(new ParcelaEmprestimo(emprestimoId, dataParcela, numero, valor, login.Trim(), dataCadastroUtc))
            : Result<ParcelaEmprestimo>.Failure(validacao.Errors.ToArray());
    }

    public Result Alterar(DateOnly dataParcela, int numero, decimal valor, bool pago, DateOnly? dataPagamento)
    {
        var validacao = Validar(dataParcela, numero, valor, pago, dataPagamento);
        if (!validacao.IsSuccess)
        {
            return validacao;
        }

        DataParcela = dataParcela;
        Parcela = numero;
        Valor = valor;
        Pago = pago;
        DataPagamento = dataPagamento;
        return Result.Success();
    }

    public Result Quitar(DateOnly dataPagamento)
    {
        Pago = true;
        DataPagamento = dataPagamento;
        return Result.Success();
    }

    private static Result Validar(DateOnly dataParcela, int numero, decimal valor, bool pago, DateOnly? dataPagamento)
    {
        if (numero is < 1 or > 600)
        {
            return Result.Failure(new Error("parcela_emprestimo.numero.invalido", "O número da parcela deve estar entre 1 e 600."));
        }

        if (valor <= 0)
        {
            return Result.Failure(new Error("parcela_emprestimo.valor.invalido", "O valor da parcela deve ser maior que zero."));
        }

        if (pago && dataPagamento is null)
        {
            return Result.Failure(new Error("parcela_emprestimo.pagamento.obrigatorio", "Informe a data de pagamento da parcela quitada."));
        }

        if (!pago && dataPagamento is not null)
        {
            return Result.Failure(new Error("parcela_emprestimo.pagamento.invalido", "Uma parcela em aberto não pode ter data de pagamento."));
        }

        if (dataPagamento is not null && dataPagamento < dataParcela)
        {
            return Result.Failure(new Error("parcela_emprestimo.pagamento.anterior", "A data de pagamento não pode ser anterior ao vencimento."));
        }

        return Result.Success();
    }
}
