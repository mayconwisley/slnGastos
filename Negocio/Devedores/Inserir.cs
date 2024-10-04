using Banco;
using Objeto.Devedores;
using System;
using System.Data;
using System.Text;

namespace Negocio.Devedores;

public class Inserir
{
    Crud crud;
    StringBuilder SQL = null;

    public bool Cadastro(DevedoresObj devedores)
    {
        crud = new Crud();
        SQL = new StringBuilder();

        SQL.Append("INSERT INTO Devedores(Nome, Descricao, Valor, Parcelas, Ativo, Login, ClienteId, DataCadastro, DataInicio) ");
        SQL.Append("VALUES(@Nome, @Descricao, @Valor, @Parcelas, @Ativo, @Login, @ClienteId, @DataCadastro, @DataInicio)");

        try
        {
            crud.LimparParametro();
            crud.AdicionarParametro("Nome", devedores.Nome);
            crud.AdicionarParametro("Descricao", devedores.Descricao);
            crud.AdicionarParametro("Valor", devedores.Valor);
            crud.AdicionarParametro("Parcelas", devedores.Parcelas);
            crud.AdicionarParametro("Ativo", devedores.Ativo);
            crud.AdicionarParametro("Login", devedores.Usuario.Login);
            crud.AdicionarParametro("ClienteId", devedores.Cliente.Id);
            crud.AdicionarParametro("DataCadastro", devedores.DataCadastro);
            crud.AdicionarParametro("DataInicio", devedores.DataInicio);
            crud.Executar(CommandType.Text, SQL.ToString());
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }
}
