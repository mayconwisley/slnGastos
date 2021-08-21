using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Emprestimos.Listar
{
    public class CadastroEmprestimoAtivoCliente
    {
        /*Listar cadastro dos emprestimos por cliente*/
        Crud crud;
        StringBuilder SQL = null;

        public decimal ValorEmprestimo(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(ValorParcela) ");
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
    }
}
