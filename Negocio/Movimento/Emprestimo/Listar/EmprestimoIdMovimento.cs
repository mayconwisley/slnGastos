using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Emprestimo.Listar
{
    public class EmprestimoIdMovimento
    {
        /*Consultar os emprestimos já na tela de movimentação*/

        Crud crud;
        StringBuilder SQL = null;

        public int QtdEmprestimoMovimento(int idEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT COUNT(EmprestimosId) ");
            SQL.Append("FROM MovimentoEmprestimos ");
            SQL.Append("WHERE EmprestimosId = @EmprestimosId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("EmprestimosId", idEmprestimo);
                int qtd = int.Parse(crud.Executar(CommandType.Text, SQL.ToString()).ToString());
                return qtd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
