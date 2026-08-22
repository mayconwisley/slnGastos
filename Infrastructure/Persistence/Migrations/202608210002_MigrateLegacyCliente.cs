using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gastos.Infrastructure.Persistence.Migrations;

[DbContext(typeof(GastosDbContext))]
[Migration("202608210002_MigrateLegacyCliente")]
public partial class MigrateExistingClientSchema : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Ativo",
            table: "Cliente",
            type: "TEXT",
            maxLength: 3,
            nullable: false,
            defaultValue: "Sim");

        migrationBuilder.AddColumn<DateTime>(
            name: "DataCadastro",
            table: "Cliente",
            type: "TEXT",
            nullable: true);

        migrationBuilder.Sql("UPDATE Cliente SET DataCadastro = Data WHERE DataCadastro IS NULL;");
        migrationBuilder.Sql("""
            CREATE TRIGGER IF NOT EXISTS Cliente_SincronizarDataCadastro
            AFTER INSERT ON Cliente
            FOR EACH ROW
            WHEN NEW.DataCadastro IS NULL
            BEGIN
                UPDATE Cliente SET DataCadastro = NEW.Data WHERE Id = NEW.Id;
            END;
            """);

        migrationBuilder.DropTable(name: "Clientes");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Clientes",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                Nome = table.Column<string>(maxLength: 120, nullable: false),
                Login = table.Column<string>(maxLength: 50, nullable: false),
                Ativo = table.Column<bool>(nullable: false),
                DataCadastroUtc = table.Column<DateTime>(nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Clientes", item => item.Id));

        migrationBuilder.DropColumn(name: "Ativo", table: "Cliente");
        migrationBuilder.DropColumn(name: "DataCadastro", table: "Cliente");
    }
}
