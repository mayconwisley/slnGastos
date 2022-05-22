using Banco;
using Objeto.Usuario;
using System;
using System.Data;
using System.Text;

namespace AcessarSistema.Login
{
    public static class BuscarSenha
    {
        static Crud crud;
        static StringBuilder SQL = null;
        static string senha = string.Empty;
        public static string Senha(UsuarioObj usuario)
        {

            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Senha ");
            SQL.Append("FROM Usuario ");
            SQL.Append("WHERE Login = @Login AND Ativo = 'Sim'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Login", usuario.Login);

                var varNull = crud.Executar(CommandType.Text, SQL.ToString());

                return senha = varNull != null ? varNull.ToString() : "";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
