using Banco;
using Objeto.Usuario;
using System;
using System.Data;
using System.Text;

namespace AcessarSistema.Login
{
    public static class BuscarChave
    {
        static Crud crud;
        static StringBuilder SQL = null;
        static string chave = string.Empty;

        public static string Chave(UsuarioObj usuario)
        {

            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Chave ");
            SQL.Append("FROM Usuario ");
            SQL.Append("WHERE Login = @Login AND Ativo = 'Sim'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Login", usuario.Login);


                var varNull = crud.Executar(CommandType.Text, SQL.ToString());

                if (varNull != null)
                {
                    return chave = crud.Executar(CommandType.Text, SQL.ToString()).ToString();
                }
                else
                {
                    return "";
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
