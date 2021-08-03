using Banco;
using Objeto.Movimentacao;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Geral
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentacaoObj movimentacao)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Movimentacao ");
            SQL.Append("SET DataMovimento = @DataMovimento, Descricao = @Descricao, Valor = @Valor, TipoLancamento = @TipoLancamento, " +
                       "TipoMonetario = @TipoMonetario, TipoPagoRecebido = @TipoPagoRecebido ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();

                crud.AdicionarParametro("DataMovimento", movimentacao.Data);
                crud.AdicionarParametro("Descricao", movimentacao.Descricao);
                crud.AdicionarParametro("Valor", movimentacao.Valor);
                crud.AdicionarParametro("TipoLancamento", movimentacao.TipoLancamento);
                crud.AdicionarParametro("TipoMonetario", movimentacao.TipoMonetario);
                crud.AdicionarParametro("TipoPagoRecebido", movimentacao.TipoPagoRecebido);
                crud.AdicionarParametro("Id", movimentacao.Id);
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
