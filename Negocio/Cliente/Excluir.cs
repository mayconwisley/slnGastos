using Banco;
using Objeto.Cliente;
using System;
using System.Data;
using System.Text;

namespace Negocio.Cliente
{
    public class Excluir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(ClienteObj cliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM Cliente ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
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
