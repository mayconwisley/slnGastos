using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Fixo.Listar
{
    public class CadastroFixoIntegrar
    {
        /*Listar emprestimos por emprestimos*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Valor, Descricao ");
            SQL.Append("FROM Fixos ");
            SQL.Append("WHERE Integrar = 'Sim' AND Ativo = 'Sim' AND ClienteId = @ClienteId");

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
