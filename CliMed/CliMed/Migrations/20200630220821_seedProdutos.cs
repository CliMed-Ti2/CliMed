using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class seedProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "IDProduto", "Designacao", "Foto", "Tipo" },
                values: new object[,]
                {
                    { 1, "Estetoscopio de Cabeca Dupla", "estetoscopio.jpeg", "Manual" },
                    { 2, "Garrote", "garrote.jpeg", "Manual" },
                    { 3, "Medidor de pressão", "medidorPressao.jpeg", "Digital" },
                    { 4, "Oxímetro de pulso", "oximetroPulso.jpeg", "Digital" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "IDProduto",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "IDProduto",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "IDProduto",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "IDProduto",
                keyValue: 4);
        }
    }
}
