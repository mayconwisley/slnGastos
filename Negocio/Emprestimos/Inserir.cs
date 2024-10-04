using Banco;
using Objeto.Emprestimos;
using System;
using System.Data;
using System.Text;

namespace Negocio.Emprestimos;

public class Inserir
{
    Crud crud;
    StringBuilder SQL = null;

    public bool Cadastro(EmprestimoObj emprestimo)
    {
        crud = new Crud();
        SQL = new StringBuilder();

        SQL.Append("INSERT INTO Emprestimos(DataInicio, Descricao, ValorEmprestado, ValorParcela, Parcelas, Ativo, Login, ClienteId, DataCadastro) ");
        SQL.Append("VALUES(@DataInicio, @Descricao, @ValorEmprestado, @ValorParcela, @Parcelas, @Ativo, @Login, @ClienteId, @DataCadastro)");

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
            crud.AdicionarParametro("DataCadastro", emprestimo.DataCadastro);
            crud.Executar(CommandType.Text, SQL.ToString());
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
