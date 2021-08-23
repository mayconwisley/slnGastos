﻿using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Geral.Listar
{
    public class SaldoEntradaPorComp
    {
        Crud crud;
        StringBuilder SQL = null;

        public DataTable ValorEntrada(int idCliente, int idCompetencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Mov.Valor) AS Entrada, STRFTIME('%m/%Y', Comp.Data) AS Data ");
            SQL.Append("FROM Movimentacao Mov ");
            SQL.Append("INNER JOIN Competencia  Comp ON Comp.Id = Mov.CompetenciaId ");
            SQL.Append("WHERE Mov.ClienteId = @ClienteId AND Mov.CompetenciaId <= @CompetenciaId AND Mov.TipoLancamento = 'Entrada'");
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
