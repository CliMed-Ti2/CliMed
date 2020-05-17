﻿// <auto-generated />
using System;
using CliMed.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CliMed.Migrations
{
    [DbContext(typeof(CliMedBD))]
    partial class CliMedBDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CliMed.Models.Administradores", b =>
                {
                    b.Property<int>("idAmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaEsp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FuncionarioIdFuncionario")
                        .HasColumnType("int");

                    b.HasKey("idAmin");

                    b.HasIndex("FuncionarioIdFuncionario");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("CliMed.Models.Clinicas", b =>
                {
                    b.Property<int>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdClinica");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("CliMed.Models.Fornecedores", b =>
                {
                    b.Property<int>("idFornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("nAndar")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<int>("nPorta")
                        .HasColumnType("int");

                    b.HasKey("idFornecedor");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("CliMed.Models.Funcionarios", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CC")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdFuncionario");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CliMed.Models.Materiais", b =>
                {
                    b.Property<int>("IdMaterial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClinicaFK")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<float>("PrecoCompra")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("precoVenda")
                        .HasColumnType("real");

                    b.HasKey("IdMaterial");

                    b.HasIndex("ClinicaFK");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("CliMed.Models.Medicos", b =>
                {
                    b.Property<int>("idMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FuncionarioIdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("anosExp")
                        .HasColumnType("int");

                    b.Property<string>("nCedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idMedico");

                    b.HasIndex("FuncionarioIdFuncionario");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("CliMed.Models.Administradores", b =>
                {
                    b.HasOne("CliMed.Models.Funcionarios", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioIdFuncionario");
                });

            modelBuilder.Entity("CliMed.Models.Materiais", b =>
                {
                    b.HasOne("CliMed.Models.Clinicas", "Clinica")
                        .WithMany("ListaDeMateriais")
                        .HasForeignKey("ClinicaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CliMed.Models.Medicos", b =>
                {
                    b.HasOne("CliMed.Models.Funcionarios", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioIdFuncionario");
                });
#pragma warning restore 612, 618
        }
    }
}
