using Banco;
using Objeto.Cliente;
using System;
using System.Data;
using System.Text;

namespace Negocio.Cliente
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(ClienteObj cliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Cliente  ");
            SQL.Append("SET Nome = @Nome, Login = @Login, Ativo = @Ativo ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Nome", cliente.Nome);
                crud.AdicionarParametro("Login", cliente.Usuario.Login);
                crud.AdicionarParametro("Ativo", cliente.Ativo);
                crud.AdicionarParametro("Id", cliente.Id);
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
