﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cliente.Listar
{
    public class IdNomeCliente
    {
        StringBuilder SQL = null;
        Negocio.ListarConsulta.Listar listar;

        public DataTable Consulta()
        {
            SQL = new StringBuilder();
            listar = new ListarConsulta.Listar();

            SQL.Append("SELECT Id,  Id || ' - ' || Nome  AS Nome ");
            SQL.Append("FROM Cliente ");
            SQL.Append("WHERE Ativo = 'Sim' ");
            SQL.Append("ORDER BY UPPER(Nome) ASC ");

            return listar.Consulta(SQL.ToString());
        }
    }

}
