using Banco;
using Negocio.Movimento.Devedor.Listar;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Geral.Listar
{
    public class SaldoPagRecClienteComp
    {
        /*Listar Saldo entrada Saida por cliente em uma devida competencia*/

        Crud crud;
        StringBuilder SQL = null;

        private decimal ValorPagoMovimentacao(int idCliente, int idCompetencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM Movimentacao ");
            SQL.Append("WHERE ClienteId = @ClienteId AND CompetenciaId <= @CompetenciaId AND TipoPagoRecebido = 'Pago'");

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

        private decimal ValorRecebidoMovimentacao(int idCliente, int idCompetencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM Movimentacao ");
            SQL.Append("WHERE ClienteId = @ClienteId AND CompetenciaId <= @CompetenciaId AND TipoPagoRecebido = 'Recebido'");

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

        private decimal ValorAPagarMovimentacaoEmprestimo(int idCliente, DateTime dataParcela)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM MovimentoEmprestimos ME ");
            SQL.Append("INNER JOIN Emprestimos E ON E.Id = ME.EmprestimosId ");
            SQL.Append("WHERE E.ClienteId = @ClienteId ");
            SQL.Append("AND Pago = 'Não'");
            SQL.Append("AND STRFTIME('%Y-%m-01', ME.DataParcela) = STRFTIME('%Y-%m-01', @DataParcela)");

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

        private decimal ValorFixo(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM Fixos ");
            SQL.Append("WHERE ClienteId = @ClienteId AND Ativo = 'Sim' ");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);

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

        public decimal Saldo(int idCliente, int idCompetencia, DateTime dataParcela)
        {

            ConsultaMovDevClienteValorTotal consultaMovDevClienteValorTotal = new();

            decimal valPago = 0, valRecebido = 0, valAPagarEmprestimo = 0, valFixo = 0, valDebDevedores = 0;

            valRecebido = ValorRecebidoMovimentacao(idCliente, idCompetencia);
            valPago = ValorPagoMovimentacao(idCliente, idCompetencia);
            valAPagarEmprestimo = ValorAPagarMovimentacaoEmprestimo(idCliente, dataParcela);
            valFixo = ValorFixo(idCliente);
            valDebDevedores = consultaMovDevClienteValorTotal.ValorDevedorMes(idCliente, dataParcela);

            return (valRecebido) - (valPago + valAPagarEmprestimo + valFixo + valDebDevedores);
        }
    }
}
