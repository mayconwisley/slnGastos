using Banco;
using Objeto.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return senha = crud.Executar(CommandType.Text, SQL.ToString()).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
