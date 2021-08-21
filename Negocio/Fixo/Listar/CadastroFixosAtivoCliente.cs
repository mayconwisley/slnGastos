using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Fixo.Listar
{
    public class CadastroFixosAtivoCliente
    {
        Crud crud;
        StringBuilder SQL = null;

        public decimal ValorFixo(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT SUM(Valor) ");
            SQL.Append("FROM Fixos ");
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
