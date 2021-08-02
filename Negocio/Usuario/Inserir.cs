using Banco;
using Objeto.Usuario;
using System;
using System.Data;
using System.Text;

namespace Negocio.Usuario
{
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(UsuarioObj usuario)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO Usuario (Login, Nome, Chave, Senha, Lembrete, DataCadastro, Ativo) ");
            SQL.Append("VALUES(@Login, @Nome, @Chave, @Senha, @Lembrete, @DataCadastro, @Ativo)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Login", usuario.Login);
                crud.AdicionarParametro("Nome", usuario.Nome);
                crud.AdicionarParametro("Chave", usuario.Chave);
                crud.AdicionarParametro("Senha", usuario.Senha);
                crud.AdicionarParametro("Lembrete", usuario.Lembrete);
                crud.AdicionarParametro("DataCadastro", usuario.DataCadastro);
                crud.AdicionarParametro("Ativo", usuario.Ativo);
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
