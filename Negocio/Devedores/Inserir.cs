using Banco;
using Objeto.Devedores;
using System;
using System.Data;
using System.Text;

namespace Negocio.Devedores
{
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(DevedoresObj devedores)
        {

            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO Devedores(DataInicio, Nome,  Valor, Parcelas, Parcelado, Ativo, Login, ClienteId, DataCadastro) ");
            SQL.Append("VALUES(@DataInicio, @Nome,  @Valor, @Parcelas, @Parcelado, @Ativo, @Login, @ClienteId, @DataCadastro)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataInicio", devedores.DataInicio);
                crud.AdicionarParametro("Nome", devedores.Nome);
                crud.AdicionarParametro("Valor", devedores.Valor);
                crud.AdicionarParametro("Parcelas", devedores.Parcelas);
                crud.AdicionarParametro("Parcelado", devedores.Parcelado);
                crud.AdicionarParametro("Ativo", devedores.Ativo);
                crud.AdicionarParametro("Login", devedores.Usuario.Login);
                crud.AdicionarParametro("ClienteId", devedores.Cliente.Id);
                crud.AdicionarParametro("DataCadastro", devedores.DataCadastro);
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
