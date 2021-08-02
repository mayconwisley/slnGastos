using Banco;
using Objeto.MovimentoDevedores;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Devedor
{
    public class Excluir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentoDevedoresObj movimentoDevedores)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM MovimentoDevedores ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Id", movimentoDevedores.Id);
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
