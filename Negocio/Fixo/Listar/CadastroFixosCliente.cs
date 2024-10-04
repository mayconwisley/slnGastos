using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Fixo.Listar
{
    public class CadastroFixosCliente
    {
        /*Listar Cadastro dos fixos por cliente*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, DataInicio, Descricao, Valor, DataFim, Ativo, Login, ClienteId, DataCadastro ");
            SQL.Append("FROM Fixos ");
            SQL.Append("WHERE ClienteId = @ClienteId ");
            SQL.Append("ORDER BY DataInicio DESC, UPPER(Descricao) ASC ");

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
