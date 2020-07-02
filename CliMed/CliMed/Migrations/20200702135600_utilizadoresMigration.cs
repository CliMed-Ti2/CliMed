using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class utilizadoresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    idUtilizador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 25, nullable: false),
                    Localidade = table.Column<string>(maxLength: 20, nullable: false),
                    CodigoPostal = table.Column<string>(maxLength: 8, nullable: true),
                    Contacto = table.Column<string>(maxLength: 9, nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Fotografia = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.idUtilizador);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
