using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Infrastructure.Persistence.Migrations;

[DbContext(typeof(GastosDbContext))]
[Migration("202608210003_AddCompetenciaIndexes")]
public partial class AddCompetenciaIndexes : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(
            "CREATE TABLE IF NOT EXISTS Competencia (" +
            "Id INTEGER NOT NULL CONSTRAINT PK_Competencia PRIMARY KEY AUTOINCREMENT, " +
            "Data TEXT NOT NULL, " +
            "ClienteId INTEGER NOT NULL, " +
            "Ativo TEXT NOT NULL);");
        migrationBuilder.Sql("CREATE INDEX IF NOT EXISTS IX_Competencia_ClienteId_Data ON Competencia (ClienteId, Data);");
        migrationBuilder.Sql("CREATE INDEX IF NOT EXISTS IX_Competencia_ClienteId_Ativo ON Competencia (ClienteId, Ativo);");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DROP INDEX IF EXISTS IX_Competencia_ClienteId_Data;");
        migrationBuilder.Sql("DROP INDEX IF EXISTS IX_Competencia_ClienteId_Ativo;");
    }
}
