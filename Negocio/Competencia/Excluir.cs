using Banco;
using Objeto.Competencia;
using System;
using System.Data;
using System.Text;

namespace Negocio.Competencia
{
    public class Excluir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(CompetenciaObj competencia)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("DELETE FROM Competencia ");
            SQL.Append("WHERE Id = @Id");

            try
            {
                crud.LimparParametro();
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
