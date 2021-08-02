﻿using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Emprestimo.Listar
{
    public class CadastroMovEmprCliente
    {
        /*Listar emprestimos por emprestimos*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int ididEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, EmprestimosId, DataParcela, Parcela, Valor, Pago, DataCadastro, DataPagamento ");
            SQL.Append("FROM MovimentoEmprestimos ");
            SQL.Append("WHERE EmprestimosId = @EmprestimosId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("EmprestimosId", ididEmprestimo);
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
