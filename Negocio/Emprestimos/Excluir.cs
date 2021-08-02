using Banco;
using Objeto.Emprestimos;
using System;
using System.Data;
using System.Text;

namespace Negocio.Emprestimos
{
    public class Excluir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(EmprestimoObj emprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM Emprestimos ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Id", emprestimo.Id);
                crud.Executar(CommandType.Text, SQL.ToString());
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
