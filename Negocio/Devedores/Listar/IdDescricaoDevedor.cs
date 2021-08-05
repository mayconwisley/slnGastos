using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Devedores.Listar
{
    public class IdDescricaoDevedor
    {
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, Id || ' - ' || Nome  AS Nome ");
            SQL.Append("FROM Devedores ");
            SQL.Append("WHERE ClienteId = @ClienteId ");
            SQL.Append("ORDER BY UPPER(Nome) ASC");

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
