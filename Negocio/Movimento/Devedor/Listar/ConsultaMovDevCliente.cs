using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Devedor.Listar
{
    public class ConsultaMovDevCliente
    {

        /*Listar Devedore por codigo de devedores*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int IdCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT MovDev.DevedoresId, Dev.Nome, SUM(MovDev.Valor) AS Valor, MovDev.Recebido ");
            SQL.Append("FROM MovimentoDevedores MovDev ");
            SQL.Append("INNER JOIN Devedores Dev ON Dev.Id = MovDev.DevedoresId ");
            SQL.Append("WHERE ClienteId = @ClienteId ");
            SQL.Append("GROUP BY MovDev.DevedoresId, Dev.Nome, MovDev.Recebido ");
            SQL.Append("ORDER BY Dev.Nome ASC");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", IdCliente);
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
