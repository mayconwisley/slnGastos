using Banco;
using Objeto.Usuario;
using System;
using System.Data;
using System.Text;

namespace Negocio.Usuario
{
    public class Excluir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(UsuarioObj usuario)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM Usuario ");
            SQL.Append("WHERE Login = @Login");

            try
            {
                crud.LimparParametro();
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
