using Banco;
using Objeto.Movimentacao;
using System;
using System.Data;
using System.Text;

namespace Negocio.Movimento.Geral
{
    public class Excluir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(MovimentacaoObj movimentacao)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM Movimentacao ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
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
