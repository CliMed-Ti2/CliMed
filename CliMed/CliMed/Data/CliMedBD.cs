using CliMed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Data
{
    public class CliMedBD: DbContext
    {

        public CliMedBD(DbContextOptions<CliMedBD> options) : base(options) { }




        /// <summary>
        /// Inserção de Dados de Teste na BD , DataSeed
        /// </summary>
        /// <param name="modelBuilder"></param>
        #region Dados de Teste 
        /*protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            //Insert DB seed


            modelBuilder.Entity<Clinicas>().HasData(
                new Clinicas
                {
                    IdClinica = 3,
                    Morada = "Rua Fernado Lopes Graça",
                    Contacto = "241844711",
                    Mail = "CliMedTerra@climed.com",
                    Foto = ""
                },
                new Clinicas
                {
                    IdClinica = 4,
                    Morada = "Rua Dona Maria",
                    Contacto = "241844712",
                    Mail = "CliMedTerra@climed.com",
                    Foto = ""
                }
                );

            modelBuilder.Entity<Medicos>().HasData(
                new Medicos
                {
                    idMedico = 3,
                    nCedula = "1234 5678 9123 4567",
                    Nome = "Pedro Zanitti",
                    DataNasc = DateTime.Parse("6/1/1978 12:00 AM"),
                    AnosExp = 25,
                    Contacto = "932165738",
                    Mail = "pedroZanitti@climed.com",
                    Morada = "Rua Antonio Douro",
                    CC = "116716529",
                    NIF = "16997680"
                },
                new Medicos
                {
                    idMedico = 4,
                    nCedula = "1234 5678 9123 4567",
                    Nome = "Sofia Silva",
                    DataNasc = DateTime.Parse("6/1/1990 12:00 AM"),
                    AnosExp = 8,
                    Contacto = "914166788",
                    Mail = "sofiaSilva@climed.com",
                    Morada = "Rua 16 de Maio",
                    CC = "167136127",
                    NIF = "18494681"
                }
                );


            modelBuilder.Entity<Utentes>().HasData(
                new Utentes
                {
                    IdUtente = 3,
                    Nome = "Andreia Silva",
                    DataNasc = DateTime.Parse("6/1/2008 12:00 AM"),
                    Contacto = "96541821",
                    Mail = "andreiaSilva@gmail.com",
                    Morada = "Rua D.Sebastião",
                    CC = "143786529",
                    NIF = "18997680"
                },
                new Utentes
                {
                      IdUtente = 4,
                      Nome = "Bruno Oliveira",
                      DataNasc = DateTime.Parse("23/5/1998 12:00 AM"),
                      Contacto = "936785162",
                      Mail = "OliveriaBruno1@gmail.com",
                      Morada = "Avenida Angola",
                      CC = "123456789",
                      NIF = "178767769"
                });

            modelBuilder.Entity<Funcionarios>().HasData(
               new Funcionarios
               {
                   IdFuncionario = 3,
                   Nome = "Alice Santos",
                   DataNasc = DateTime.Parse("6/1/2008 12:00 AM"),
                   Contacto = "931765432",
                   Mail = "aliceSantos@climed.com",
                   Morada = "Rua do Arsenal",
                   CC = "143767529",
                   NIF = "188876810",
                   ClinicaFK = 3
               },
               new Funcionarios
               {
                   IdFuncionario = 4,
                   Nome = "Jorge  Barbosa",
                   DataNasc = DateTime.Parse("23/5/1998 12:00 AM"),
                   Contacto = "961166762",
                   Mail = "jorgeBarbosa@climed.com",
                   Morada = "Avenida Angola",
                   CC = "184451889",
                   NIF = "188891256",
                   ClinicaFK = 4
               });



            modelBuilder.Entity<Materiais>().HasData(
             new Materiais
             {
                 IdMaterial = 1,
                 Descricao = "Ben-u-ron 1g comprimidos-Paracetamol",
                 Stock = 10,
                 Tipo = "Medicamento",
                 PrecoCompra = Convert.ToSingle(8.90),
                 precoVenda = Convert.ToSingle(8.90),
                 ClinicaFK = 3
             },
             new Materiais
             {
                 IdMaterial = 2,
                 Descricao = "Garrote",
                 Stock = 5,
                 Tipo = "Consumivel",
                 PrecoCompra = Convert.ToSingle(3.50),
                 precoVenda = Convert.ToSingle(3.50),
                 ClinicaFK = 4
             });



            modelBuilder.Entity<Consultas>().HasData(
             new Consultas
             {
                 IdClinica = 1,
                 DataMarcacao = DateTime.Parse("9/1/2020 03:00 PM"),
                 EstConsulta = true,
                 Descricao = "Consulta de Rotina",
                 Receita = "Não Disponivel",
                 MedicoFK = 3,
                 UtenteFK=3,
                 ClinicaFK = 3
             },
             new Consultas
             {
                 IdClinica = 2,
                 DataMarcacao = DateTime.Parse("9/1/2020 03:00 PM"),
                 EstConsulta = true,
                 Descricao = "Consulta de Avaliação de Exames Médicos",
                 Receita = "Não Disponivel",
                 MedicoFK = 4,
                 UtenteFK = 4,
                 ClinicaFK = 4
             });
        }
        */
        #endregion Dados de Teste 


        public DbSet<Clinicas> Clinicas{ get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Existencias> Existencias { get; set; }

    }
}
