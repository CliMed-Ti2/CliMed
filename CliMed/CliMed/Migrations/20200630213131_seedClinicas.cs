using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class seedClinicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clinicas",
                columns: new[] { "IdClinica", "CodPostal", "Contacto", "EMail", "Foto", "Localidade", "NIF", "Nome", "Rua", "nAndar", "nPorta" },
                values: new object[] { 1, "2252-965", "964256245", "doutorConsulta@climed.com", "doutorConsulta.jpeg", "Oeiras", "245568236", "Clinica Doutor Consulta", "Rua Antonio Miguel", "1E", 45 });

            migrationBuilder.InsertData(
                table: "Clinicas",
                columns: new[] { "IdClinica", "CodPostal", "Contacto", "EMail", "Foto", "Localidade", "NIF", "Nome", "Rua", "nAndar", "nPorta" },
                values: new object[] { 2, "2622-965", "915968212", "saudeConsigo@climed.com", "saudeConsigo.jpeg", "Estoril", "256989236", "Clinica Saude Consigo", "Rua Tomás Antunes", "1D", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clinicas",
                keyColumn: "IdClinica",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clinicas",
                keyColumn: "IdClinica",
                keyValue: 2);
        }
    }
}
