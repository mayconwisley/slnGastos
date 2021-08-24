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

                object sucesso = crud.Executar(CommandType.Text, SQL.ToString());

                
                if (sucesso != null)
                {
                    return DateTime.Parse(crud.Executar(CommandType.Text, SQL.ToString()).ToString());
                }
                else
                {
                    return DateTime.Parse("01/01/1900");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
