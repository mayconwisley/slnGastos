using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Devedor.Listar
{
    public class CadastroMovDevDatRecebido
    {
        /*Listar emprestimos por emprestimos*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente, DateTime dataRecebido, DateTime dataParcela)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT MovDev.Valor, MovDev.DataRecebido, Dev.Nome || ' - ' || MovDev.Parcela || 'ª Parcela' AS Descricao  ");
            SQL.Append("FROM MovimentoDevedores MovDev ");
            SQL.Append("INNER JOIN Devedores Dev ON Dev.Id = MovDev.DevedoresId ");
            SQL.Append("WHERE STRFTIME('%Y-%m-01', MovDev.DataRecebido) = STRFTIME('%Y-%m-01', @DataRecebido) AND " +
                "STRFTIME('%Y-%m-01', DataParcela) >= STRFTIME('%Y-%m-01', @DataParcela)  AND Recebido = 'Sim' AND ClienteId = @ClienteId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataRecebido", dataRecebido);
                crud.AdicionarParametro("DataParcela", dataParcela);
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
