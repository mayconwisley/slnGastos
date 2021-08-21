using Banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Devedores.Listar
{
    public class CadastroDevedorAtivoCliente
    {
        Crud crud;
        StringBuilder SQL = null;

        public decimal ValorDevedor(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM Devedores ");
            SQL.Append("WHERE ClienteId = @ClienteId AND Ativo = 'Sim' ");

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
