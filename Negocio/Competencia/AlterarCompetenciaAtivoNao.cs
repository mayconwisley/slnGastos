using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia
{
    public class AlterarCompetenciaAtivoNao
    {
        Crud crud;
        StringBuilder SQL = null;

        /*Função para deixar sempre uma competencia ativa por cliente*/

        public bool Cadastro(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();
            SQL.Append("UPDATE Competencia ");
            SQL.Append("SET Ativo = 'Não' ");
            SQL.Append("WHERE ClienteId = @ClienteId");


            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);
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
