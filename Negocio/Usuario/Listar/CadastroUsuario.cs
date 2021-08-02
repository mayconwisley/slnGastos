using System.Data;
using System.Text;

namespace Negocio.Usuario.Listar
{
    public class CadastroUsuario
    {
        StringBuilder SQL = null;

        public DataTable Consulta()
        {
            ListarConsulta.Listar listar = new ListarConsulta.Listar();

            SQL = new StringBuilder();

            SQL.Append("SELECT Login, Nome, Lembrete, DataCadastro, Ativo, Chave, Senha ");
            SQL.Append("FROM Usuario ");
            SQL.Append("ORDER BY UPPER(Nome) ASC ");

            return listar.Consulta(SQL.ToString());
        }

    }
}
