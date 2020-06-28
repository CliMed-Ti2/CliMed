using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class NewTableProdutosp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    IdClinica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 25, nullable: false),
                    Rua = table.Column<string>(maxLength: 60, nullable: false),
                    nPorta = table.Column<int>(nullable: false),
                    nAndar = table.Column<string>(maxLength: 3, nullable: true),
                    CodPostal = table.Column<string>(maxLength: 8, nullable: false),
                    Localidade = table.Column<string>(maxLength: 20, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: true),
                    Contacto = table.Column<string>(maxLength: 9, nullable: true),
                    EMail = table.Column<string>(nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IDProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(maxLength: 30, nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IDProduto);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    Contacto = table.Column<string>(maxLength: 9, nullable: false),
                    Mail = table.Column<string>(maxLength: 30, nullable: false),
                    Morada = table.Column<string>(maxLength: 60, nullable: false),
                    CC = table.Column<string>(maxLength: 13, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: false),
                    Foto = table.Column<string>(nullable: true),
                    ClinicaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Clinicas_ClinicaFK",
                        column: x => x.ClinicaFK,
                        principalTable: "Clinicas",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Existencias",
                columns: table => new
                {
                    IdExistencia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(nullable: false),
                    ClinicaFK = table.Column<int>(nullable: false),
                    ClinicaIdClinica = table.Column<int>(nullable: true),
                    ProdutoFK = table.Column<int>(nullable: false),
                    ProdutoIDProduto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Existencias", x => x.IdExistencia);
                    table.ForeignKey(
                        name: "FK_Existencias_Clinicas_ClinicaIdClinica",
                        column: x => x.ClinicaIdClinica,
                        principalTable: "Clinicas",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Existencias_Produtos_ProdutoIDProduto",
                        column: x => x.ProdutoIDProduto,
                        principalTable: "Produtos",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Existencias_ClinicaIdClinica",
                table: "Existencias",
                column: "ClinicaIdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Existencias_ProdutoIDProduto",
                table: "Existencias",
                column: "ProdutoIDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ClinicaFK",
                table: "Funcionarios",
                column: "ClinicaFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Existencias");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clinicas");
        }
    }
}
