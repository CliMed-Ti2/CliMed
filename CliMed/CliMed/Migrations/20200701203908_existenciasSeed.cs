using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class existenciasSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Existencias",
                columns: new[] { "IdExistencia", "ClinicaFK", "ProdutoFK", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, 1, 7 },
                    { 2, 1, 2, 12 },
                    { 3, 1, 3, 5 },
                    { 4, 1, 4, 10 },
                    { 5, 1, 2, 5 },
                    { 6, 2, 2, 3 },
                    { 7, 2, 3, 2 },
                    { 8, 2, 4, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 8);
        }
    }
}
