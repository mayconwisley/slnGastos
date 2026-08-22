using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Infrastructure.Persistence.Migrations;

[DbContext(typeof(GastosDbContext))]
[Migration("202608210006_CreateModernSchema")]
public partial class CreateModernSchema : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(
            """
            CREATE TABLE IF NOT EXISTS Cliente (
                Id INTEGER NOT NULL CONSTRAINT PK_Cliente PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Login TEXT NOT NULL,
                Ativo TEXT NOT NULL,
                Data TEXT NOT NULL);
            CREATE INDEX IF NOT EXISTS IX_Cliente_Nome ON Cliente (Nome);
            CREATE INDEX IF NOT EXISTS IX_Cliente_Login ON Cliente (Login);

            CREATE TABLE IF NOT EXISTS Competencia (
                Id INTEGER NOT NULL CONSTRAINT PK_Competencia PRIMARY KEY AUTOINCREMENT,
                Data TEXT NOT NULL,
                ClienteId INTEGER NOT NULL,
                Ativo TEXT NOT NULL);
            CREATE INDEX IF NOT EXISTS IX_Competencia_ClienteId_Data ON Competencia (ClienteId, Data);
            CREATE INDEX IF NOT EXISTS IX_Competencia_ClienteId_Ativo ON Competencia (ClienteId, Ativo);

            CREATE TABLE IF NOT EXISTS Fixos (
                Id INTEGER NOT NULL CONSTRAINT PK_Fixos PRIMARY KEY AUTOINCREMENT,
                DataInicio TEXT NOT NULL,
                Descricao TEXT NOT NULL,
                Valor NUMERIC NOT NULL,
                DataFim TEXT NULL,
                Login TEXT NOT NULL,
                ClienteId INTEGER NOT NULL,
                DataCadastro TEXT NOT NULL);
            CREATE INDEX IF NOT EXISTS IX_Fixos_ClienteId_DataInicio ON Fixos (ClienteId, DataInicio);

            CREATE TABLE IF NOT EXISTS Emprestimos (
                Id INTEGER NOT NULL CONSTRAINT PK_Emprestimos PRIMARY KEY AUTOINCREMENT,
                DataInicio TEXT NOT NULL,
                Descricao TEXT NOT NULL,
                ValorEmprestado NUMERIC NOT NULL,
                ValorParcela NUMERIC NOT NULL,
                Parcelas INTEGER NOT NULL,
                Ativo TEXT NOT NULL,
                Login TEXT NOT NULL,
                ClienteId INTEGER NOT NULL,
                DataCadastro TEXT NOT NULL);
            CREATE INDEX IF NOT EXISTS IX_Emprestimos_ClienteId_DataInicio ON Emprestimos (ClienteId, DataInicio);

            CREATE TABLE IF NOT EXISTS MovimentoEmprestimos (
                Id INTEGER NOT NULL CONSTRAINT PK_MovimentoEmprestimos PRIMARY KEY AUTOINCREMENT,
                EmprestimosId INTEGER NOT NULL,
                DataParcela TEXT NOT NULL,
                Parcela INTEGER NOT NULL,
                Valor NUMERIC NOT NULL,
                Pago TEXT NOT NULL,
                Login TEXT NOT NULL,
                DataCadastro TEXT NOT NULL,
                DataPagamento TEXT NULL);
            CREATE UNIQUE INDEX IF NOT EXISTS IX_MovimentoEmprestimos_EmprestimosId_Parcela ON MovimentoEmprestimos (EmprestimosId, Parcela);

            CREATE TABLE IF NOT EXISTS Devedores (
                Id INTEGER NOT NULL CONSTRAINT PK_Devedores PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL,
                Descricao TEXT NOT NULL,
                Valor NUMERIC NOT NULL,
                Parcelas INTEGER NOT NULL,
                DataInicio TEXT NOT NULL,
                Ativo TEXT NOT NULL,
                Login TEXT NOT NULL,
                ClienteId INTEGER NOT NULL,
                DataCadastro TEXT NOT NULL);
            CREATE INDEX IF NOT EXISTS IX_Devedores_ClienteId_Nome ON Devedores (ClienteId, Nome);

            CREATE TABLE IF NOT EXISTS MovimentoDevedores (
                Id INTEGER NOT NULL CONSTRAINT PK_MovimentoDevedores PRIMARY KEY AUTOINCREMENT,
                DevedoresId INTEGER NOT NULL,
                DataParcela TEXT NOT NULL,
                Parcela INTEGER NOT NULL,
                Valor NUMERIC NOT NULL,
                Recebido TEXT NOT NULL,
                Login TEXT NOT NULL,
                DataCadastro TEXT NOT NULL,
                DataRecebido TEXT NULL);
            CREATE UNIQUE INDEX IF NOT EXISTS IX_MovimentoDevedores_DevedoresId_Parcela ON MovimentoDevedores (DevedoresId, Parcela);

            CREATE TABLE IF NOT EXISTS Movimentacao (
                Id INTEGER NOT NULL CONSTRAINT PK_Movimentacao PRIMARY KEY AUTOINCREMENT,
                DataMovimento TEXT NOT NULL,
                Descricao TEXT NOT NULL,
                Valor NUMERIC NOT NULL,
                TipoLancamento TEXT NOT NULL,
                TipoMonetario TEXT NOT NULL,
                TipoPagoRecebido TEXT NOT NULL,
                Integrado TEXT NOT NULL,
                Login TEXT NOT NULL,
                ClienteId INTEGER NOT NULL,
                CompetenciaId INTEGER NOT NULL,
                DataCadastro TEXT NOT NULL);
            CREATE INDEX IF NOT EXISTS IX_Movimentacao_ClienteId_CompetenciaId_DataMovimento ON Movimentacao (ClienteId, CompetenciaId, DataMovimento);

            CREATE TABLE IF NOT EXISTS Usuario (
                Login TEXT NOT NULL CONSTRAINT PK_Usuario PRIMARY KEY,
                Nome TEXT NOT NULL,
                Chave TEXT NOT NULL DEFAULT '',
                Senha TEXT NOT NULL,
                Lembrete TEXT NOT NULL DEFAULT '',
                DataCadastro TEXT NOT NULL,
                Ativo TEXT NOT NULL DEFAULT 'Sim');
            CREATE INDEX IF NOT EXISTS IX_Usuario_Nome ON Usuario (Nome);
            """);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }
}
