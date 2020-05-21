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
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CliMed.Models.Clinicas", b =>
                {
                    b.Property<int>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("NIF")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("nAndar")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<int>("nPorta")
                        .HasColumnType("int");

                    b.HasKey("IdClinica");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("CliMed.Models.Existencias", b =>
                {
                    b.Property<int>("IdExistencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClinicaFK")
                        .HasColumnType("int");

                    b.Property<int?>("ClinicaIdClinica")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoFK")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoIDProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("IdExistencia");

                    b.HasIndex("ClinicaIdClinica");

                    b.HasIndex("ProdutoIDProduto");

                    b.ToTable("Existencias");
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

                    b.Property<int>("ClinicaFK")
                        .HasColumnType("int");

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdFuncionario");

                    b.HasIndex("ClinicaFK");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("CliMed.Models.Produtos", b =>
                {
                    b.Property<int>("IDProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClinicaFK")
                        .HasColumnType("int");

                    b.Property<string>("Designacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDProduto");

                    b.HasIndex("ClinicaFK");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CliMed.Models.Existencias", b =>
                {
                    b.HasOne("CliMed.Models.Clinicas", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaIdClinica");

                    b.HasOne("CliMed.Models.Produtos", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoIDProduto");
                });

            modelBuilder.Entity("CliMed.Models.Funcionarios", b =>
                {
                    b.HasOne("CliMed.Models.Clinicas", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CliMed.Models.Produtos", b =>
                {
                    b.HasOne("CliMed.Models.Clinicas", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
