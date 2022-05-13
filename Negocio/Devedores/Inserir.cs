using Banco;
using Objeto.Devedores;
using System;
using System.Data;
using System.Text;

namespace Negocio.Devedores
{
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(DevedoresObj devedores)
        {

            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO Devedores(Nome, Ativo, Login, ClienteId, DataCadastro) ");
            SQL.Append("VALUES(@Nome, @Ativo, @Login, @ClienteId, @DataCadastro)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Nome", devedores.Nome);
                crud.AdicionarParametro("Ativo", devedores.Ativo);
                crud.AdicionarParametro("Login", devedores.Usuario.Login);
                crud.AdicionarParametro("ClienteId", devedores.Cliente.Id);
                crud.AdicionarParametro("DataCadastro", devedores.DataCadastro);
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
