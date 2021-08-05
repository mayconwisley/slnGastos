using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Fixo.Listar
{
    public class CadastroFixoIntegrar
    {
        /*Listar emprestimos por emprestimos*/
        Crud crud;
        StringBuilder SQL = null;

        public DataTable Consulta()
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Valor, Descricao ");
            SQL.Append("FROM Fixos ");
            SQL.Append("WHERE Integrar = 'Sim' AND Ativo = 'Sim'");

            try
            {
                crud.LimparParametro();
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
