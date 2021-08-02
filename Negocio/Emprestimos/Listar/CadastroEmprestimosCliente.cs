using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Emprestimos.Listar
{
    public class CadastroEmprestimosCliente
    {
        /*Listar cadastro dos emprestimos por cliente*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, DataInicio, Descricao, ValorEmprestado, ValorParcela, Parcelas,  ValorParcela * Parcelas AS ValorAPagar, Ativo, Login, ClienteId, DataCadastro ");
            SQL.Append("FROM Emprestimos ");
            SQL.Append("WHERE ClienteId = @ClienteId ");
            SQL.Append("ORDER BY DataInicio DESC, UPPER(Descricao) ASC");

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
