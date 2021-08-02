﻿using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Emprestimos.Listar
{
  public  class IdDescricaoEmprestimo
    {

        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id, Id || ' - ' || Descricao  AS Nome ");
            SQL.Append("FROM Emprestimos ");
            SQL.Append("WHERE ClienteId = @ClienteId ");
            SQL.Append("ORDER BY UPPER(Descricao) ASC");

            try
            {
                crud.LimparParametro();
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
