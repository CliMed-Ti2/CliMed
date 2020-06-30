using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class existenciasAjusteFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Existencias_Clinicas_ClinicaIdClinica",
                table: "Existencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Existencias_Produtos_ProdutoIDProduto",
                table: "Existencias");

            migrationBuilder.DropIndex(
                name: "IX_Existencias_ClinicaIdClinica",
                table: "Existencias");

            migrationBuilder.DropIndex(
                name: "IX_Existencias_ProdutoIDProduto",
                table: "Existencias");

            migrationBuilder.DropColumn(
                name: "ClinicaIdClinica",
                table: "Existencias");

            migrationBuilder.DropColumn(
                name: "ProdutoIDProduto",
                table: "Existencias");

            migrationBuilder.CreateIndex(
                name: "IX_Existencias_ClinicaFK",
                table: "Existencias",
                column: "ClinicaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Existencias_ProdutoFK",
                table: "Existencias",
                column: "ProdutoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Existencias_Clinicas_ClinicaFK",
                table: "Existencias",
                column: "ClinicaFK",
                principalTable: "Clinicas",
                principalColumn: "IdClinica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Existencias_Produtos_ProdutoFK",
                table: "Existencias",
                column: "ProdutoFK",
                principalTable: "Produtos",
                principalColumn: "IDProduto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Existencias_Clinicas_ClinicaFK",
                table: "Existencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Existencias_Produtos_ProdutoFK",
                table: "Existencias");

            migrationBuilder.DropIndex(
                name: "IX_Existencias_ClinicaFK",
                table: "Existencias");

            migrationBuilder.DropIndex(
                name: "IX_Existencias_ProdutoFK",
                table: "Existencias");

            migrationBuilder.AddColumn<int>(
                name: "ClinicaIdClinica",
                table: "Existencias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoIDProduto",
                table: "Existencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Existencias_ClinicaIdClinica",
                table: "Existencias",
                column: "ClinicaIdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Existencias_ProdutoIDProduto",
                table: "Existencias",
                column: "ProdutoIDProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Existencias_Clinicas_ClinicaIdClinica",
                table: "Existencias",
                column: "ClinicaIdClinica",
                principalTable: "Clinicas",
                principalColumn: "IdClinica",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Existencias_Produtos_ProdutoIDProduto",
                table: "Existencias",
                column: "ProdutoIDProduto",
                principalTable: "Produtos",
                principalColumn: "IDProduto",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
