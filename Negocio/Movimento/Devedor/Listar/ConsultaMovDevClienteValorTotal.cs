using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Devedor.Listar
{
    public class ConsultaMovDevClienteValorTotal
    {
        Crud crud;
        StringBuilder SQL = null;

        public decimal ValorDevedor(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(MovDev.Valor) AS Valor ");
            SQL.Append("FROM MovimentoDevedores MovDev  ");
            SQL.Append("INNER JOIN Devedores Dev ON Dev.Id = MovDev.DevedoresId ");
            SQL.Append("WHERE ClienteId = @ClienteId AND Dev.Ativo = 'Sim' AND MovDev.Recebido = 'Não' ");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);

                decimal valor;
                bool sucesso = decimal.TryParse(crud.Executar(CommandType.Text, SQL.ToString()).ToString(), out valor);

                if (sucesso)
                {
                    return valor;
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
