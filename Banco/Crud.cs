﻿using System;
using System.Data;
using System.Data.SQLite;

namespace Banco
{
    public class Crud : Conexao
    {
        SQLiteParameterCollection liteParameterCollection = new SQLiteCommand().Parameters;
        SQLiteCommand liteCommand;
    

        public void LimparParametro()
        {
            liteParameterCollection.Clear();
        }
        public void AdicionarParametro(string parametro, object valor)
        {
            liteParameterCollection.Add(new SQLiteParameter(parametro, valor));
        }

        public object Executar(CommandType commandType, string SQL)
        {
            if (Conectar())
            {
                try
                {
                    

                    liteCommand = liteConnection.CreateCommand();
                    
                    liteCommand.CommandType = commandType;
                    liteCommand.CommandText = SQL;
                    liteCommand.CommandTimeout = 7200;

                    foreach (SQLiteParameter liteParameter in liteParameterCollection)
                    {
                        liteCommand.Parameters.Add(new SQLiteParameter(liteParameter.ParameterName, liteParameter.Value));
                    }
                    return liteCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                finally
                {
                    Desconectar();
                }
            }
            else
            {
                return false;
            }
        }

        public DataTable Consulta(CommandType commandType, string SQL)
        {
            if (Conectar())
            {
                try
                {
                    liteCommand = liteConnection.CreateCommand();
                    liteCommand.CommandType = commandType;
                    liteCommand.CommandText = SQL;
                    liteCommand.CommandTimeout = 7200;

                    foreach (SQLiteParameter oleDbParameter in liteParameterCollection)
                    {
                        liteCommand.Parameters.Add(new SQLiteParameter(oleDbParameter.ParameterName, oleDbParameter.Value));
                    }

                    SQLiteDataAdapter liteDataAdapter = new SQLiteDataAdapter(liteCommand);
                    DataTable dataTable = new DataTable();
                    liteDataAdapter.Fill(dataTable);

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    Desconectar();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
