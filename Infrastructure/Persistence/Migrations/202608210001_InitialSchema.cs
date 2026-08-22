using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Gastos.Infrastructure.Persistence.Migrations;

[DbContext(typeof(GastosDbContext))]
[Migration("202608210001_InitialSchema")]
public partial class InitialSchema : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Clientes",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Nome = table.Column<string>(maxLength: 120, nullable: false),
                Login = table.Column<string>(maxLength: 50, nullable: false),
                Ativo = table.Column<bool>(nullable: false),
                DataCadastroUtc = table.Column<DateTime>(nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Clientes", item => item.Id));

        migrationBuilder.CreateIndex(name: "IX_Clientes_Login", table: "Clientes", column: "Login");
        migrationBuilder.CreateIndex(name: "IX_Clientes_Nome", table: "Clientes", column: "Nome");
    }

    protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.DropTable(name: "Clientes");
}
