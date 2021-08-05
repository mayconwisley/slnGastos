using Banco;
using Objeto.Usuario;
using System;
using System.Data;
using System.Text;

namespace Negocio.Usuario
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(UsuarioObj usuario)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Usuario ");
            SQL.Append("SET Nome = @Nome, Chave = @Chave, Senha = @Senha, Lembrete = @Lembrete, Ativo = @Ativo ");
            SQL.Append("WHERE Login = @Login");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Nome", usuario.Nome);
                crud.AdicionarParametro("Chave", usuario.Chave);
                crud.AdicionarParametro("Senha", usuario.Senha);
                crud.AdicionarParametro("Lembrete", usuario.Lembrete);
                crud.AdicionarParametro("Ativo", usuario.Ativo);
                crud.AdicionarParametro("Login", usuario.Login);
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
