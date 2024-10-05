using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Devedor.Listar;

public class ConsultaMovDevClienteValorTotal
{
    Crud crud;
    StringBuilder SQL = null;

    public decimal ValorDevedorPago(int idCliente, DateTime dataParcela)
    {
        crud = new Crud();
        SQL = new StringBuilder();

        SQL.Append("SELECT SUM(MovDev.Valor) AS Valor ");
        SQL.Append("FROM MovimentoDevedores MovDev ");
        SQL.Append("INNER JOIN Devedores Dev ON Dev.Id = MovDev.DevedoresId ");
        SQL.Append("WHERE Dev.ClienteId = @ClienteId AND Dev.Ativo = 'Sim' AND MovDev.Recebido = 'Sim' ");
        SQL.Append("AND STRFTIME('%Y-%m-01',MovDev.DataParcela) = STRFTIME('%Y-%m-01', @DataParcela) ");

        try
        {
            crud.LimparParametro();
            crud.AdicionarParametro("ClienteId", idCliente);
            crud.AdicionarParametro("DataParcela", dataParcela);

            decimal valor;
            bool sucesso = decimal.TryParse(crud.Executar(CommandType.Text, SQL.ToString()).ToString(), out valor);

            if (sucesso)
            {
                return valor;
            }
            else
            {
                return 0;
            }

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public decimal ValorDevedorMes(int idCliente, DateTime dataParcela)
    {
        crud = new Crud();
        SQL = new StringBuilder();

        SQL.Append("SELECT ((SELECT SUM(md.Valor) ");
        SQL.Append("FROM MovimentoDevedores md ");
        SQL.Append("INNER JOIN Devedores d ON d.Id  = md.DevedoresId ");
        SQL.Append("WHERE d.ClienteId = @ClienteId) - ");

        SQL.Append("(SELECT IFNULL(SUM(md.Valor), 0) ");
        SQL.Append("FROM MovimentoDevedores md ");
        SQL.Append("INNER JOIN Devedores d ON ");
        SQL.Append("d.Id  = md.DevedoresId ");
        SQL.Append("WHERE md.Recebido = 'Sim' ");
        SQL.Append("AND d.ClienteId = @ClienteId ");
        SQL.Append("AND STRFTIME('%Y-%m-01', md.DataParcela) = STRFTIME('%Y-%m-01', @DataParcela))) As Valor");

        try
        {
            crud.LimparParametro();
            crud.AdicionarParametro("ClienteId", idCliente);
            crud.AdicionarParametro("DataParcela", dataParcela);

            decimal valor;
            bool sucesso = decimal.TryParse(crud.Executar(CommandType.Text, SQL.ToString()).ToString(), out valor);

            if (sucesso)
            {
                return valor;
            }
            else
            {
                return 0;
            }

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
