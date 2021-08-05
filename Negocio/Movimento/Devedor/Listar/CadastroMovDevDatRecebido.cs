using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Devedor.Listar
{
    public class CadastroMovDevDatRecebido
    {
        /*Listar emprestimos por emprestimos*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(DateTime dataRecebido)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT MovDev.Valor, MovDev.DataRecebido, Dev.Nome || ' - ' || Dev.Descricao || ' - Parcela: ' || MovDev.Parcela || 'ª'  AS Descricao  ");
            SQL.Append("FROM MovimentoDevedores MovDev ");
            SQL.Append("INNER JOIN Devedores Dev ON Dev.Id = MovDev.DevedoresId ");
            SQL.Append("WHERE STRFTIME('%Y-%m-01', MovDev.DataRecebido) = STRFTIME('%Y-%m-01', @DataRecebido) AND Pago = 'Sim'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataRecebido", dataRecebido);
                DataTable dataTable = crud.Consulta(CommandType.Text, SQL.ToString());
                return dataTable;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
