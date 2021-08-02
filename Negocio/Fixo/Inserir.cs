using Banco;
using Objeto.Fixos;
using System;
using System.Data;
using System.Text;

namespace Negocio.Fixo
{
    public class Inserir
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(FixoObj fixo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("INSERT INTO Fixos(DataInicio, Descricao, Valor, DataFim, Ativo, Login, ClienteId, DataCadastro) ");
            SQL.Append("VALUES(@DataInicio, @Descricao, @Valor, @DataFim, @Ativo, @Login, @ClienteId, @DataCadastro)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParametro("DataInicio", fixo.DataInicio);
                crud.AdicionarParametro("Descricao", fixo.Descricao);
                crud.AdicionarParametro("Valor", fixo.Valor);
                crud.AdicionarParametro("DataFim", fixo.DataFim);
                crud.AdicionarParametro("Ativo", fixo.Ativo);
                crud.AdicionarParametro("Login", fixo.Usuario.Login);
                crud.AdicionarParametro("ClienteId", fixo.Cliente.Id);
                crud.AdicionarParametro("DataCadastro", fixo.DataCadastro);
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
