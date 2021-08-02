using Banco;
using Objeto.Cliente;
using System;
using System.Data;
using System.Text;

namespace Negocio.Cliente
{
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(ClienteObj cliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO Cliente(Nome, Login, Ativo, DataCadastro) ");
            SQL.Append("VALUES(@Nome, @Login, @Ativo, @DataCadastro)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Nome", cliente.Nome);
                crud.AdicionarParametro("Login", cliente.Usuario.Login);
                crud.AdicionarParametro("Ativo", cliente.Ativo);
                crud.AdicionarParametro("DataCadastro", cliente.DataCadastro);
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
