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

            SQL.Append("INSERT INTO MovimentoDevedores( DevedoresId, DataParcela, Parcela, Valor, Recebido, Login, DataCadastro, DataRecebido) ");
            SQL.Append("VALUES( @DevedoresId, @DataParcela, @Parcela, @Valor, @Recebido, @Login, @DataCadastro, @DataRecebido)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DevedoresId", movimentoDevedores.Devedores.Id);
                crud.AdicionarParametro("DataParcela", movimentoDevedores.DataParcela);
                crud.AdicionarParametro("Parcela", movimentoDevedores.Parcela);
                crud.AdicionarParametro("Valor", movimentoDevedores.Valor);
                crud.AdicionarParametro("Recebido", movimentoDevedores.Recebido);
                crud.AdicionarParametro("Login", movimentoDevedores.Usuario.Login);
                crud.AdicionarParametro("DataCadastro", movimentoDevedores.DataCadastro);
                crud.AdicionarParametro("DataRecebido", movimentoDevedores.DataRecebido);
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