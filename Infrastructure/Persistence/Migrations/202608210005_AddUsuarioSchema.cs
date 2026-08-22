using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Infrastructure.Persistence.Migrations;

[DbContext(typeof(GastosDbContext))]
[Migration("202608210005_AddUsuarioSchema")]
public partial class AddUsuarioSchema : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(
            "CREATE TABLE IF NOT EXISTS Usuario (" +
            "Login TEXT NOT NULL CONSTRAINT PK_Usuario PRIMARY KEY, Nome TEXT NOT NULL, " +
            "Chave TEXT NOT NULL DEFAULT '', Senha TEXT NOT NULL, Lembrete TEXT NOT NULL DEFAULT '', " +
            "DataCadastro TEXT NOT NULL, Ativo TEXT NOT NULL DEFAULT 'Sim');");
        migrationBuilder.Sql("CREATE INDEX IF NOT EXISTS IX_Usuario_Nome ON Usuario (Nome);");
    }

    protected override void Down(MigrationBuilder migrationBuilder) =>
        migrationBuilder.Sql("DROP INDEX IF EXISTS IX_Usuario_Nome;");
}
