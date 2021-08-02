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
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentoEmprestimoObj movimentoEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO MovimentoEmprestimos( EmprestimosId, DataParcela, Parcela, Valor, Pago, Login, DataCadastro, DataPagamento) ");
            SQL.Append("VALUES( @EmprestimosId, @DataParcela, @Parcela, @Valor, @Pago, @Login, @DataCadastro, @DataPagamento)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("EmprestimosId", movimentoEmprestimo.Emprestimo.Id);
                crud.AdicionarParametro("DataParcela", movimentoEmprestimo.DataParcela);
                crud.AdicionarParametro("Parcela", movimentoEmprestimo.Parcela);
                crud.AdicionarParametro("Valor", movimentoEmprestimo.Valor);
                crud.AdicionarParametro("Pago", movimentoEmprestimo.Pago);
                crud.AdicionarParametro("Login", movimentoEmprestimo.Usuario.Login);
                crud.AdicionarParametro("DataCadastro", movimentoEmprestimo.DataCadastro);
                crud.AdicionarParametro("DataPagamento", movimentoEmprestimo.DataPagameno);
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
