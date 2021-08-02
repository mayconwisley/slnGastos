using Banco;
using Objeto.Fixos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Fixo
{
    public class Alterar
    {
        Crud crud;
        StringBuilder SQL = null;

        public bool Cadastro(FixoObj fixo)
        {
            crud = new Crud();
            SQL = new StringBuilder();

            SQL.Append("UPDATE Fixos ");
            SQL.Append("SET DataInicio = @DataInicio, Descricao = @Descricao, Valor = @Valor, DataFim = @DataFim, " +
                       "Ativo = @Ativo, Login = @Login, ClienteId = @ClienteId ");
            SQL.Append("WHERE Id = @Id");

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
                crud.AdicionarParametro("Id", fixo.Id);
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
