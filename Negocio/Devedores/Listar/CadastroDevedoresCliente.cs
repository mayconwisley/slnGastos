using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Devedores.Listar
{
   public class CadastroDevedoresCliente
    {
        /*Listar cadastro dos emprestimos por cliente*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, DataInicio, Nome, Valor, Parcelado, Parcelas, Ativo, Login, ClienteId, DataCadastro ");
            SQL.Append("FROM Devedores ");
            SQL.Append("WHERE ClienteId = @ClienteId ");
            SQL.Append("ORDER BY DataInicio DESC, UPPER(Nome) ASC");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);
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
