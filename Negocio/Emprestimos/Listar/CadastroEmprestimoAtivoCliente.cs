using Banco;
using System;
using System.Data;
using System.Reflection;
using System.Text;

namespace Negocio.Emprestimos.Listar
{
    public class CadastroEmprestimoAtivoCliente
    {
        /*Listar cadastro dos emprestimos por cliente*/
        Crud crud;
        StringBuilder SQL = null;

        private decimal ValorEmprestimoMovimentacao(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM MovimentoEmprestimos ME ");
            SQL.Append("INNER JOIN Emprestimos E ON E.Id = ME.EmprestimosId ");
            SQL.Append("WHERE E.ClienteId = @ClienteId AND E.Ativo = 'Sim' AND ME.Pago = 'Sim' ");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);

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


        private decimal ValorEmprestimo(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(ValorParcela * Parcelas) ");
            SQL.Append("FROM Emprestimos ");
            SQL.Append("WHERE ClienteId = @ClienteId AND Ativo = 'Sim' ");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);

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


        public decimal ValorGeralEmprestimo(int idCliente)
        {
            decimal valEmprestimo = 0, valEmprestimoMovimentacao = 0;

            valEmprestimo = ValorEmprestimo(idCliente);
            valEmprestimoMovimentacao = ValorEmprestimoMovimentacao(idCliente);

            return valEmprestimo - valEmprestimoMovimentacao;


        }
    }
}
