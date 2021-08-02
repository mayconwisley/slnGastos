using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia.Listar
{
    public class CadastroCompetencia
    {
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();
            SQL.Append("SELECT Id, Data, ClienteId, Ativo ");
            SQL.Append("FROM Competencia ");
            SQL.Append("WHERE ClienteId = @ClienteId ");
            SQL.Append("ORDER BY Data DESC ");

            crud = new Crud();
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
