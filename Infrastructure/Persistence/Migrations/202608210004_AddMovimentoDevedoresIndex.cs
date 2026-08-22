using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Infrastructure.Persistence.Migrations;

[DbContext(typeof(GastosDbContext))]
[Migration("202608210004_AddMovimentoDevedoresIndex")]
public partial class AddMovimentoDevedoresIndex : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(
            "CREATE TABLE IF NOT EXISTS MovimentoDevedores (" +
            "Id INTEGER NOT NULL CONSTRAINT PK_MovimentoDevedores PRIMARY KEY AUTOINCREMENT, " +
            "DevedoresId INTEGER NOT NULL, DataParcela TEXT NOT NULL, Parcela INTEGER NOT NULL, " +
            "Valor NUMERIC NOT NULL, Recebido TEXT NOT NULL, Login TEXT NOT NULL, " +
            "DataCadastro TEXT NOT NULL, DataRecebido TEXT NULL);");
        migrationBuilder.Sql("CREATE UNIQUE INDEX IF NOT EXISTS IX_MovimentoDevedores_DevedoresId_Parcela ON MovimentoDevedores (DevedoresId, Parcela);");
    }

    protected override void Down(MigrationBuilder migrationBuilder) =>
        migrationBuilder.Sql("DROP INDEX IF EXISTS IX_MovimentoDevedores_DevedoresId_Parcela;");
}
