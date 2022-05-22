﻿using Banco;
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

        public decimal Saldo(int idCliente, int idCompetencia)
        {
            decimal valPago = 0, valRecebido = 0;

            valRecebido = ValorRecebidoMovimentacao(idCliente, idCompetencia);
            valPago = ValorPagoMovimentacao(idCliente, idCompetencia);
            return valRecebido - valPago;
        }
    }
}
