using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class newModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    IdClinica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Morada = table.Column<string>(maxLength: 40, nullable: false),
                    Contacto = table.Column<string>(maxLength: 9, nullable: false),
                    Mail = table.Column<string>(maxLength: 30, nullable: false),
                    Foto = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    idFornecedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(maxLength: 30, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: false),
                    Rua = table.Column<string>(maxLength: 60, nullable: false),
                    nPorta = table.Column<int>(nullable: false),
                    nAndar = table.Column<string>(maxLength: 2, nullable: true),
                    CodPostal = table.Column<string>(nullable: false),
                    Localidade = table.Column<string>(maxLength: 20, nullable: false),
                    Contacto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.idFornecedor);
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
                    Mail = table.Column<string>(nullable: false),
                    CC = table.Column<string>(maxLength: 13, nullable: false),
                    NIF = table.Column<string>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 30, nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    PrecoCompra = table.Column<float>(nullable: false),
                    precoVenda = table.Column<float>(nullable: false),
                    ClinicaFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.IdMaterial);
                    table.ForeignKey(
                        name: "FK_Materiais_Clinicas_ClinicaFK",
                        column: x => x.ClinicaFK,
                        principalTable: "Clinicas",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    idAmin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioIdFuncionario = table.Column<int>(nullable: true),
                    AreaEsp = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.idAmin);
                    table.ForeignKey(
                        name: "FK_Administradores_Funcionarios_FuncionarioIdFuncionario",
                        column: x => x.FuncionarioIdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    idMedico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioIdFuncionario = table.Column<int>(nullable: true),
                    nCedula = table.Column<string>(nullable: false),
                    anosExp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.idMedico);
                    table.ForeignKey(
                        name: "FK_Medicos_Funcionarios_FuncionarioIdFuncionario",
                        column: x => x.FuncionarioIdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_FuncionarioIdFuncionario",
                table: "Administradores",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_ClinicaFK",
                table: "Materiais",
                column: "ClinicaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_FuncionarioIdFuncionario",
                table: "Medicos",
                column: "FuncionarioIdFuncionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
