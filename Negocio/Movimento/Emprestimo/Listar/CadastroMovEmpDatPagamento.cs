using Banco;
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

        public DataTable Consulta(DateTime dataParcela)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT MovEmp.Valor, Emp.Descricao ");
            SQL.Append("FROM MovimentoEmprestimos MovEmp ");
            SQL.Append("INNER JOIN Emprestimos Emp ON Emp.Id = MovEmp.EmprestimosId ");
            SQL.Append("WHERE STRFTIME('%Y-%m-01', DataParcela) = STRFTIME('%Y-%m-01', @DataParcela)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataParcela", dataParcela);
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
