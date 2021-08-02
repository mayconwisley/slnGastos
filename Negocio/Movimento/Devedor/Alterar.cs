using Banco;
using Objeto.MovimentoDevedores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Movimento.Devedor
{
   public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentoDevedoresObj movimentoDevedores)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE MovimentoDevedores ");
            SQL.Append("SET DevedoresId = @DevedoresId, DataParcela = @DataParcela, Parcela = @Parcela, Valor = @Valor, " +
                       "Pago = @Pago, DataPagamento = @DataPagamento ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();

                crud.AdicionarParametro("DevedoresId", movimentoDevedores.Devedores.Id);
                crud.AdicionarParametro("DataParcela", movimentoDevedores.DataParcela);
                crud.AdicionarParametro("Parcela", movimentoDevedores.Parcela);
                crud.AdicionarParametro("Valor", movimentoDevedores.Valor);
                crud.AdicionarParametro("Pago", movimentoDevedores.Pago);
                crud.AdicionarParametro("DataPagamento", movimentoDevedores.DataPagameno);
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
