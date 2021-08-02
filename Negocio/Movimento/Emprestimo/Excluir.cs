using Banco;
using Objeto.MovimentoEmprestimos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Emprestimo
{
    public class Excluir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentoEmprestimoObj movimentoEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM MovimentoEmprestimos ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Id", movimentoEmprestimo.Id);
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
