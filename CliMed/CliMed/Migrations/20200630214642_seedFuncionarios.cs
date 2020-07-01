using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class seedFuncionarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "IdFuncionario", "CC", "ClinicaFK", "Contacto", "DataNasc", "Foto", "Mail", "Morada", "NIF", "Nome" },
                values: new object[] { 1, "125365698", 1, "965123325", new DateTime(1980, 1, 20, 12, 15, 12, 0, DateTimeKind.Unspecified), "joseTevez.jpeg", "joseTevez@climed.com", "Avenida Vasco da Gama", "198563256", "Jose Alberto Tevez" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "IdFuncionario", "CC", "ClinicaFK", "Contacto", "DataNasc", "Foto", "Mail", "Morada", "NIF", "Nome" },
                values: new object[] { 2, "186123402", 2, "965123325", new DateTime(1980, 11, 5, 22, 10, 7, 0, DateTimeKind.Unspecified), "mariaSofia.jpeg", "mariaSofia@climed.com", "Avenida Almirante Reis", "201562152", "Maria Oliveira Sofia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "IdFuncionario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "IdFuncionario",
                keyValue: 2);
        }
    }
}
