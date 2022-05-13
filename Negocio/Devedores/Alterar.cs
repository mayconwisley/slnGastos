using Banco;
using Objeto.Devedores;
using System;
using System.Data;
using System.Text;

namespace Negocio.Devedores
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(DevedoresObj devedores)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Devedores ");
            SQL.Append("SET Nome = @Nome, Ativo = @Ativo, Login = @Login, ClienteId = @ClienteId ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Nome", devedores.Nome);
                crud.AdicionarParametro("Ativo", devedores.Ativo);
                crud.AdicionarParametro("Login", devedores.Usuario.Login);
                crud.AdicionarParametro("ClienteId", devedores.Cliente.Id);
                crud.AdicionarParametro("Id", devedores.Id);
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
