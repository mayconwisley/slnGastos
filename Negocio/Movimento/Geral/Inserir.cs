using Banco;
using Objeto.Movimentacao;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Geral
{
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentacaoObj movimentacao)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO Movimentacao(DataMovimento, Descricao, Valor, TipoLancamento, TipoMonetario, TipoPagoRecebido, Login, ClienteId, CompetenciaId, DataCadastro) ");
            SQL.Append("VALUES(@DataMovimento, @Descricao, @Valor, @TipoLancamento, @TipoMonetario, @TipoPagoRecebido, @Login, @ClienteId, @CompetenciaId, @DataCadastro)");
            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataMovimento", movimentacao.Data);
                crud.AdicionarParametro("Descricao", movimentacao.Descricao);
                crud.AdicionarParametro("Valor", movimentacao.Valor);
                crud.AdicionarParametro("TipoLancamento", movimentacao.TipoLancamento);
                crud.AdicionarParametro("TipoMonetario", movimentacao.TipoMonetario);
                crud.AdicionarParametro("TipoPagoRecebido", movimentacao.TipoPagoRecebido);
                crud.AdicionarParametro("Login", movimentacao.Usuario.Login);
                crud.AdicionarParametro("CompetenciaId", movimentacao.Competencia.Id);
                crud.AdicionarParametro("ClienteId", movimentacao.Cliente.Id);
                crud.AdicionarParametro("DataCadastro", movimentacao.DataCadastro);
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
