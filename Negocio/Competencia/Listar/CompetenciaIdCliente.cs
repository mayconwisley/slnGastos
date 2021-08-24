using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia.Listar
{
    public class CompetenciaIdCliente
    {
        Crud crud;
        StringBuilder SQL = null;
        /*Listar Id da competencia ativa por cliente*/
        public int CompetenciaId(int idCliente)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id ");
            SQL.Append("FROM Competencia ");
            SQL.Append("WHERE ClienteId = @ClienteId AND Ativo = 'Sim'");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);
                                
                object sucesso = crud.Executar(CommandType.Text, SQL.ToString());
                if (sucesso != null)
                {
                    return int.Parse(crud.Executar(CommandType.Text, SQL.ToString()).ToString());
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
