﻿using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Emprestimo.Listar
{
    public class CadastroMovEmpDatPagamento
    {
        /*Listar emprestimos por emprestimos*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente, DateTime dataPagamento, DateTime dataParcela)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT MovEmp.Id, MovEmp.Valor, MovEmp.DataPagamento, Emp.Descricao || ' - ' || MovEmp.Parcela || 'ª Parcela' AS Descricao ");
            SQL.Append("FROM MovimentoEmprestimos MovEmp ");
            SQL.Append("INNER JOIN Emprestimos Emp ON Emp.Id = MovEmp.EmprestimosId ");
            SQL.Append("WHERE STRFTIME('%Y-%m-01', DataPagamento) = STRFTIME('%Y-%m-01', @DataPagamento) AND " +
                       "STRFTIME('%Y-%m-01', DataParcela) >= STRFTIME('%Y-%m-01', @DataParcela)  AND Pago = 'Sim' AND ClienteId = @ClienteId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataPagamento", dataPagamento);
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
