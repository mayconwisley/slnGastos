using Banco;
using Objeto.Devedores;
using System;
using System.Data;
using System.Text;

namespace Negocio.Devedores;

public class Excluir
{
    Crud crud;
    StringBuilder SQL = null;

    public bool Cadastro(DevedoresObj devedores)
    {
        crud = new Crud();
        SQL = new StringBuilder();

        SQL.Append("DELETE FROM Devedores ");
        SQL.Append("WHERE Id = @Id");

        try
        {
            crud.LimparParametro();
            crud.AdicionarParametro("Id", devedores.Id);
            crud.Executar(CommandType.Text, SQL.ToString());
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }
}
