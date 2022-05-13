using Banco;
using Objeto.Emprestimos;
using System;
using System.Data;
using System.Text;

namespace Negocio.Emprestimos
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(EmprestimoObj emprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Emprestimos ");
            SQL.Append("SET DataInicio = @DataInicio, Descricao = @Descricao, ValorEmprestado = @ValorEmprestado, ValorParcela = @ValorParcela, Parcelas = @Parcelas, " +
                       "Ativo = @Ativo, Login = @Login, ClienteId = @ClienteId ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataInicio", emprestimo.DataInicio);
                crud.AdicionarParametro("Descricao", emprestimo.Descricao);
                crud.AdicionarParametro("ValorEmprestado", emprestimo.ValorEmprestado);
                crud.AdicionarParametro("ValorParcela", emprestimo.ValorParcela);
                crud.AdicionarParametro("Parcelas", emprestimo.Parcelas);
                crud.AdicionarParametro("Ativo", emprestimo.Ativo);
                crud.AdicionarParametro("Login", emprestimo.Usuario.Login);
                crud.AdicionarParametro("ClienteId", emprestimo.Cliente.Id);
                crud.AdicionarParametro("Id", emprestimo.Id);
                crud.Executar(CommandType.Text, SQL.ToString());
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public bool Ativo(int idEmprestimo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Emprestimos ");
            SQL.Append("SET Ativo = 'Não' ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Id", idEmprestimo);
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
