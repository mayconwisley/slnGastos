using Banco;
using Objeto.MovimentoEmprestimos;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Emprestimo
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentoEmprestimoObj movimentoEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE MovimentoEmprestimos ");
            SQL.Append("SET EmprestimosId = @EmprestimosId, DataParcela = @DataParcela, Parcela = @Parcela, Valor = @Valor, " +
                       "Pago = @Pago, Integrado = @Integrado, DataPagamento = @DataPagamento ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();

                crud.AdicionarParametro("EmprestimosId", movimentoEmprestimo.Emprestimo.Id);
                crud.AdicionarParametro("DataParcela", movimentoEmprestimo.DataParcela);
                crud.AdicionarParametro("Parcela", movimentoEmprestimo.Parcela);
                crud.AdicionarParametro("Valor", movimentoEmprestimo.Valor);
                crud.AdicionarParametro("Pago", movimentoEmprestimo.Pago);
                crud.AdicionarParametro("Integrado", movimentoEmprestimo.Integrado);
                crud.AdicionarParametro("DataPagamento", movimentoEmprestimo.DataPagameno);
                crud.AdicionarParametro("Id", movimentoEmprestimo.Id);
                crud.Executar(CommandType.Text, SQL.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Quitar(MovimentoEmprestimoObj movimentoEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE MovimentoEmprestimos ");
            SQL.Append("SET Pago = @Pago, DataPagamento = @DataPagamento, Integrado = 'Não' ");
            SQL.Append("WHERE EmprestimosId = @EmprestimosId AND Pago = 'Não'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Pago", movimentoEmprestimo.Pago);
                crud.AdicionarParametro("DataPagamento", movimentoEmprestimo.DataPagameno);
                crud.AdicionarParametro("EmprestimosId", movimentoEmprestimo.Emprestimo.Id);
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
