using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Emprestimo
{
    public class ExcluirTudoClienteEmprestimo
    {
        Crud crud;
        StringBuilder SQL = null;

        /*Excluir toda a movimenta do devedor*/
        public bool Cadastro(int idEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM MovimentoEmprestimos ");
            SQL.Append("WHERE EmprestimosId = @EmprestimosId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("EmprestimosId", idEmprestimo);
                crud.Executar(CommandType.Text, SQL.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
