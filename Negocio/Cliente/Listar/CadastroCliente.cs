using System.Data;
using System.Text;

namespace Negocio.Cliente.Listar
{
    public class CadastroCliente
    {
        StringBuilder SQL = null;
        Negocio.ListarConsulta.Listar listar;
        public DataTable Consulta()
        {
            SQL = new StringBuilder();
            listar = new ListarConsulta.Listar();

            SQL.Append("SELECT Id, Nome, Login, Ativo, DataCadastro ");
            SQL.Append("FROM Cliente ");
            SQL.Append("ORDER BY UPPER(Nome) ASC ");

            return listar.Consulta(SQL.ToString());
        }
    }
}
