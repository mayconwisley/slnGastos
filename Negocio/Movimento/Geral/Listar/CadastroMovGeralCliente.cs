using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Geral.Listar
{
    public class CadastroMovGeralCliente
    {
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente, int idCompetencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, DataMovimento, Descricao, Valor, TipoLancamento, TipoMonetario, TipoPagoRecebido, Integrado, Login, ClienteId, CompetenciaId, DataCadastro ");
            SQL.Append("FROM Movimentacao ");
            SQL.Append("WHERE ClienteId = @ClienteId AND CompetenciaId = @CompetenciaId ");
            SQL.Append("ORDER BY DataMovimento DESC, UPPER(Descricao) ASC");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);
                crud.AdicionarParametro("CompetenciaId", idCompetencia);
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
