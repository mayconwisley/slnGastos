using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Usuario.Listar
{
    public class QuantidadeUsuario
    {
        Crud crud;
        StringBuilder SQL = null;

        public int QtdUsuario()
        {
            crud = new Crud();
            SQL = new StringBuilder();

            int qtd = 0;


            SQL.Append("SELECT COUNT(Login) ");
            SQL.Append("FROM Usuario");

            try
            {
                crud.LimparParametro();

                bool sucesso = int.TryParse(crud.Executar(CommandType.Text, SQL.ToString()).ToString(), out qtd);

                if (sucesso)
                {
                    return qtd;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
