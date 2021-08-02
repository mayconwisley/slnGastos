using Banco;
using Objeto.Competencia;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(CompetenciaObj competencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Competencia ");
            SQL.Append("SET Data = @Data, ClienteId = @ClienteId, Ativo = @Ativo ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Data", competencia.Data);
                crud.AdicionarParametro("ClienteId", competencia.Cliente.Id);
                crud.AdicionarParametro("Ativo", competencia.Ativo);
                crud.AdicionarParametro("Id", competencia.Id);
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
