using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CliMed.Migrations
{
    public partial class seedDatabaseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicos",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Medicos",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                table: "Medicos",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Medicos",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Contacto",
                table: "Medicos",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CC",
                table: "Medicos",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Clinicas",
                columns: new[] { "IdClinica", "Contacto", "Foto", "Mail", "Morada" },
                values: new object[,]
                {
                    { 3, "241844711", "", "CliMedTerra@climed.com", "Rua Fernado Lopes Graça" },
                    { 4, "241844712", "", "CliMedTerra@climed.com", "Rua Dona Maria" }
                });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "idMedico", "AnosExp", "CC", "Contacto", "DataNasc", "Mail", "Morada", "NIF", "Nome", "nCedula" },
                values: new object[,]
                {
                    { 3, 25, "116716529", "932165738", new DateTime(1978, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedroZanitti@climed.com", "Rua Antonio Douro", "16997680", "Pedro Zanitti", "1234 5678 9123 4567" },
                    { 4, 8, "167136127", "914166788", new DateTime(1990, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofiaSilva@climed.com", "Rua 16 de Maio", "18494681", "Sofia Silva", "1234 5678 9123 4567" }
                });

            migrationBuilder.InsertData(
                table: "Utentes",
                columns: new[] { "IdUtente", "CC", "Contacto", "DataNasc", "Mail", "Morada", "NIF", "Nome" },
                values: new object[,]
                {
                    { 3, "143786529", "96541821", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "andreiaSilva@gmail.com", "Rua D.Sebastião", "18997680", "Andreia Silva" },
                    { 4, "123456789", "936785162", new DateTime(1998, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "OliveriaBruno1@gmail.com", "Avenida Angola", "178767769", "Bruno Oliveira" }
                });

            migrationBuilder.InsertData(
                table: "Consultas",
                columns: new[] { "IdClinica", "ClinicaFK", "DataMarcacao", "Descricao", "EstConsulta", "MedicoFK", "Receita", "UtenteFK" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2020, 1, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), "Consulta de Rotina", true, 3, "Não Disponivel", 3 },
                    { 2, 4, new DateTime(2020, 1, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), "Consulta de Avaliação de Exames Médicos", true, 4, "Não Disponivel", 4 }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "IdFuncionario", "CC", "ClinicaFK", "Contacto", "DataNasc", "Mail", "Morada", "NIF", "Nome" },
                values: new object[,]
                {
                    { 3, "143767529", 3, "931765432", new DateTime(2008, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "aliceSantos@climed.com", "Rua do Arsenal", "188876810", "Alice Santos" },
                    { 4, "184451889", 4, "961166762", new DateTime(1998, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "jorgeBarbosa@climed.com", "Avenida Angola", "188891256", "Jorge  Barbosa" }
                });

            migrationBuilder.InsertData(
                table: "Materiais",
                columns: new[] { "IdMaterial", "ClinicaFK", "Descricao", "PrecoCompra", "Stock", "Tipo", "precoVenda" },
                values: new object[,]
                {
                    { 1, 3, "Ben-u-ron 1g comprimidos-Paracetamol", 8.9f, 10, "Medicamento", 8.9f },
                    { 2, 4, "Garrote", 3.5f, 5, "Consumivel", 3.5f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "IdClinica",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Consultas",
                keyColumn: "IdClinica",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "IdFuncionario",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Funcionarios",
                keyColumn: "IdFuncionario",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materiais",
                keyColumn: "IdMaterial",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materiais",
                keyColumn: "IdMaterial",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clinicas",
                keyColumn: "IdClinica",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clinicas",
                keyColumn: "IdClinica",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "idMedico",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicos",
                keyColumn: "idMedico",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Utentes",
                keyColumn: "IdUtente",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utentes",
                keyColumn: "IdUtente",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Morada",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Contacto",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "CC",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);
        }
    }
}
