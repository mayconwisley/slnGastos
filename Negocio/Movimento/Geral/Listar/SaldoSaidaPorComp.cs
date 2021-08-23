using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Geral.Listar
{
    public class SaldoSaidaPorComp
    {
        /*Listar Saldo entrada Saida por cliente em uma devida competencia*/

        Crud crud;
        StringBuilder SQL = null;

        public DataTable ValorSaida(int idCliente, int idCompetencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Mov.Valor) AS Saida, STRFTIME('%m/%Y', Comp.Data) AS Data ");
            SQL.Append("FROM Movimentacao Mov ");
            SQL.Append("INNER JOIN Competencia  Comp ON Comp.Id = Mov.CompetenciaId ");
            SQL.Append("WHERE Mov.ClienteId = @ClienteId AND Mov.CompetenciaId <= @CompetenciaId AND Mov.TipoLancamento = 'Saída'");
            SQL.Append("GROUP BY Comp.Data");

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
