using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Devedor
{
    public class ExcluirTudoClienteDevedor
    {
        Crud crud;
        StringBuilder SQL = null;

        /*Excluir toda a movimenta do devedor*/
        public bool Cadastro(int idDevedor)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM MovimentoDevedores ");
            SQL.Append("WHERE DevedoresId = @DevedoresId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DevedoresId", idDevedor);
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
