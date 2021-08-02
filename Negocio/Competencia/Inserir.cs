using Banco;
using Objeto.Competencia;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia
{
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(CompetenciaObj competencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO Competencia(Data, ClienteId, Ativo) ");
            SQL.Append("VALUES(@Data, @ClienteId, @Ativo)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("Data", competencia.Data);
                crud.AdicionarParametro("ClienteId", competencia.Cliente.Id);
                crud.AdicionarParametro("Ativo", competencia.Ativo);
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
