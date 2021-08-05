using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Devedor.Listar
{
    public class DevedoresIdMovimento
    {
        /*Consultar os emprestimos já na tela de movimentação*/

        Crud crud;
        StringBuilder SQL = null;

        public int QtdDevedoresMovimento(int idDevedor)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT COUNT(DevedoresId) ");
            SQL.Append("FROM MovimentoDevedores ");
            SQL.Append("WHERE DevedoresId = @DevedoresId");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DevedoresId", idDevedor);
                int qtd = int.Parse(crud.Executar(CommandType.Text, SQL.ToString()).ToString());
                return qtd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
