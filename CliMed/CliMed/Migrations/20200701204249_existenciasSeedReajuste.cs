using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class existenciasSeedReajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 5,
                columns: new[] { "ClinicaFK", "ProdutoFK" },
                values: new object[] { 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Existencias",
                keyColumn: "IdExistencia",
                keyValue: 5,
                columns: new[] { "ClinicaFK", "ProdutoFK" },
                values: new object[] { 1, 2 });
        }
    }
}
