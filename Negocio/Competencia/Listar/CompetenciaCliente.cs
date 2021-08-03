using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia.Listar
{
    public class CompetenciaCliente
    {
        Crud crud;
        StringBuilder SQL = null;
        /*Listar competencia ativa por cliente*/
        public DateTime CompetenciaAtiva(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Data ");
            SQL.Append("FROM Competencia ");
            SQL.Append("WHERE ClienteId = @ClienteId AND Ativo = 'Sim'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);

                DateTime date;

                bool sucesso = DateTime.TryParse(crud.Executar(CommandType.Text, SQL.ToString()).ToString(), out date);
                if (sucesso)
                {
                    return date;
                }
                else
                {
                    return date;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
