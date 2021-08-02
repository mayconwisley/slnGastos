using Banco;
using System;
using System.Data;

namespace Negocio.ListarConsulta
{
    public class Listar
    {
        Crud crud;
        /*Listar as query SQL sem parametros WHERE*/
        public DataTable Consulta(string SQL)
        {
            crud = new Crud();
            try
            {
                crud.LimparParametro();
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
