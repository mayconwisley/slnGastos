using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Devedor.Listar;

public class CadastroMovDevCliente
{
    /*Listar Devedore por codigo de devedores*/
    Crud crud;
    StringBuilder SQL = null;

    public DataTable Consulta(int IdDevedor)
    {
        crud = new Crud();
        SQL = new StringBuilder();

        SQL.Append("SELECT MovDev.Id, MovDev.DevedoresId, MovDev.DataParcela, MovDev.Parcela, MovDev.Valor, MovDev.Recebido, MovDev.DataCadastro, MovDev.DataRecebido, Dev.Descricao ");
        SQL.Append("FROM MovimentoDevedores MovDev ");
        SQL.Append("INNER JOIN Devedores Dev ON Dev.Id = MovDev.DevedoresId ");
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
