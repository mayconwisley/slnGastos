using Banco;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia.Listar
{
    public class CompetenciaIdData
    {
        /*Listar id competencia pela data e cliente*/
        Crud crud;
        StringBuilder SQL = null;

        public int CompetenciaId(int idCliente, DateTime date)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("SELECT Id ");
            SQL.Append("FROM Competencia ");
            SQL.Append("WHERE ClienteId = @ClienteId AND Data = @Data");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("ClienteId", idCliente);
                crud.AdicionarParametro("Data", date);


                var strId = crud.Executar(CommandType.Text, SQL.ToString());

                if (strId == null)
                {
                    return 0;
                }
                else
                {
                    return int.Parse(strId.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
