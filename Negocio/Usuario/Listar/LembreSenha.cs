using Banco;
using Objeto.Usuario;
using System;
using System.Data;
using System.Text;

namespace Negocio.Usuario.Listar
{
    public class LembreSenha
    {
        Crud crud;
        StringBuilder SQL = null;
        string strLembrete = string.Empty;
        public string LembreteSenha(UsuarioObj usuario)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Lembrete ");
            SQL.Append("FROM Usuario ");
            SQL.Append("WHERE Login = @Login AND Ativo = 'Sim'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Login", usuario.Login);
                return strLembrete = crud.Executar(CommandType.Text, SQL.ToString()).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
