using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Emprestimos.Listar;

public class CadastroEmprestimoAtivoCliente
{
    /*Listar cadastro dos emprestimos por cliente*/
    Crud crud;
    StringBuilder SQL = null;

    private decimal ValorEmprestimoAPagarMovimentacao(int idCliente, DateTime dataParcela)
    {
        crud = new Crud();
        SQL = new StringBuilder();

        SQL.Append("SELECT SUM(Valor) ");
        SQL.Append("FROM MovimentoEmprestimos ME ");
        SQL.Append("INNER JOIN Emprestimos E ON E.Id = ME.EmprestimosId ");
        SQL.Append("WHERE E.ClienteId = @ClienteId ");
        SQL.Append("AND E.Ativo = 'Sim' ");
        SQL.Append("AND ME.Pago = 'Não' ");
        SQL.Append("AND STRFTIME('%Y-%m-01',ME.DataParcela) = STRFTIME('%Y-%m-01', @DataParcela) ");

        try
        {
            crud.LimparParametro();
            crud.AdicionarParametro("ClienteId", idCliente);
            crud.AdicionarParametro("DataParcela", dataParcela);

            decimal valor;
            bool sucesso = decimal.TryParse(crud.Executar(CommandType.Text, SQL.ToString()).ToString(), out valor);

            if (sucesso)
            {
                return valor;
            }
            else
            {
                return 0;
            }

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }

    public decimal ValorEmprestimoAPagar(int idCliente, DateTime dataParcela)
    {
        decimal valEmprestimoMovimentacao = 0;
        valEmprestimoMovimentacao = ValorEmprestimoAPagarMovimentacao(idCliente, dataParcela);

        return valEmprestimoMovimentacao;


    }
}
