using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Geral.Listar
{
    public class SaldoEntSaiClienteComp
    {
        /*Listar Saldo entrada Saida por cliente em uma devida competencia*/

        Crud crud;
        StringBuilder SQL = null;

        private decimal ValorEntrada(int idCliente, int idCompetencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM Movimentacao ");
            SQL.Append("WHERE ClienteId = @ClienteId AND CompetenciaId <= @CompetenciaId  AND TipoLancamento = 'Entrada'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);
                crud.AdicionarParametro("CompetenciaId", idCompetencia);
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

        private decimal ValorSaida(int idCliente, int idCompetencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM Movimentacao ");
            SQL.Append("WHERE ClienteId = @ClienteId AND CompetenciaId <= @CompetenciaId AND TipoLancamento = 'Saída'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);
                crud.AdicionarParametro("CompetenciaId", idCompetencia);
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

        public decimal Saldo(int idCliente, int idCompetencia)
        {
            decimal valEntrada = 0, valSaida = 0;

            valEntrada = ValorEntrada(idCliente, idCompetencia);
            valSaida = ValorSaida(idCliente, idCompetencia);

            return valEntrada - valSaida;
        }
    }
}
