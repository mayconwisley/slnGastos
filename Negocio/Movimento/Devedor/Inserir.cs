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
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentoDevedoresObj movimentoDevedores)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO MovimentoDevedores(DataMovimento, DevedoresId, DataParcela, Parcela, Valor, Pago, Login, DataCadastro, DataPagamento) ");
            SQL.Append("VALUES(@DataMovimento, @DevedoresId, @DataParcela, @Parcela, @Valor, @Pago, @Login, @DataCadastro, @DataPagamento)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataMovimento", movimentoDevedores.DataMovimento);
                crud.AdicionarParametro("DevedoresId", movimentoDevedores.Devedores.Id);
                crud.AdicionarParametro("DataParcela", movimentoDevedores.DataParcela);
                crud.AdicionarParametro("Parcela", movimentoDevedores.Parcela);
                crud.AdicionarParametro("Valor", movimentoDevedores.Valor);
                crud.AdicionarParametro("Pago", movimentoDevedores.Pago);
                crud.AdicionarParametro("Login", movimentoDevedores.Usuario.Login);
                crud.AdicionarParametro("DataCadastro", movimentoDevedores.DataCadastro);
                crud.AdicionarParametro("DataPagamento", movimentoDevedores.DataPagameno);
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