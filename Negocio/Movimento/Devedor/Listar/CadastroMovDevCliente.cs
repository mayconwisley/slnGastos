using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Devedor.Listar
{
    class CadastroMovDevCliente
    {
        /*Listar Devedore por codigo de devedores*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int IdDevedor)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, DevedoresId, DataParcela, Parcela, Valor, Pago, DataCadastro, DataPagamento ");
            SQL.Append("FROM MovimentoDevedores ");
            SQL.Append("WHERE DevedoresId = @DevedoresId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DevedoresId", IdDevedor);
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
