using CliMed.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Data
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Nome do Utilizador Autenticado
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Nome do Ficheiro que contém a Fotografia do Utilizador
        /// </summary>
        public string Fotografia { get; set; }

        /// <summary>
        /// Data em que o Registo do Utilizador foi Criado 
        /// </summary>
        public DateTime TimeStamp { get; set; }


    }

    public class CliMedBD : IdentityDbContext<ApplicationUser>
    {

        public CliMedBD(DbContextOptions<CliMedBD> options) : base(options) { }




        /// <summary>
        /// Inserção de Dados de Teste na BD , DataSeed
        /// </summary>
        /// <param name="modelBuilder"></param>
        #region Dados de Teste 
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            //Insert DB seed

            modelBuilder.Entity<Clinicas>().HasData(
                new Clinicas
                {
                    IdClinica = 1 ,
                    Nome = "Clinica Doutor Consulta",
                    Rua = "Rua Antonio Miguel",
                    nPorta = 45 ,
                    nAndar = "1E",
                    CodPostal = "2252-965",
                    Localidade = "Oeiras",
                    NIF = "245568236",
                    Contacto = "964256245",
                    EMail = "doutorConsulta@climed.com",
                    Foto = "doutorConsulta.jpeg"
                },
                new Clinicas
                {
                    IdClinica = 2,
                    Nome = "Clinica Saude Consigo",
                    Rua = "Rua Tomás Antunes",
                    nPorta = 3,
                    nAndar = "1D",
                    CodPostal = "2622-965",
                    Localidade = "Estoril",
                    NIF = "256989236",
                    Contacto = "915968212",
                    EMail = "saudeConsigo@climed.com",
                    Foto = "saudeConsigo.jpeg"
                }
                );
           

                modelBuilder.Entity<Funcionarios>().HasData(
                 new Funcionarios
                 {
                     IdFuncionario = 1,
                     Nome = "Jose Alberto Tevez",
                     DataNasc = DateTime.Parse("20/1/1980 12:15:12 PM"),
                     Contacto = "965123325",
                     Mail = "joseTevez@climed.com",
                     Morada = "Avenida Vasco da Gama",
                     CC = "125365698",
                     NIF = "198563256",
                     Foto = "joseTevez.jpeg",
                     ClinicaFK = 1,
                 },
                 new Funcionarios
                 {
                      IdFuncionario = 2,
                      Nome = "Maria Oliveira Sofia",
                      DataNasc = DateTime.Parse("05/11/1980 10:10:07 PM"),
                      Contacto = "965123325",
                      Mail = "mariaSofia@climed.com",
                      Morada = "Avenida Almirante Reis",
                      CC = "186123402",
                      NIF = "201562152",
                      Foto = "mariaSofia.jpeg",
                      ClinicaFK = 2,
                 }
                );



            modelBuilder.Entity<Produtos>().HasData(
                new Produtos
                {
                    IDProduto = 1,
                    Designacao = "Estetoscopio de Cabeca Dupla",
                    Tipo = "Manual",
                    Foto = "estetoscopio.jpeg",
                },
                new Produtos
                {
                    IDProduto = 2,
                    Designacao = "Garrote",
                    Tipo = "Manual",
                    Foto = "garrote.jpeg",
                },
                new Produtos
                {
                   IDProduto = 3,
                   Designacao = "Medidor de pressão",
                   Tipo = "Digital",
                   Foto = "medidorPressao.jpeg",
                },
                new Produtos
                {
                   IDProduto = 4,
                   Designacao = "Oxímetro de pulso",
                   Tipo = "Digital",
                   Foto = "oximetroPulso.jpeg",
                }
               );



            modelBuilder.Entity<Existencias>().HasData(
                  new Existencias
                  {
                    IdExistencia = 1,
                    Quantidade = 7,
                    ClinicaFK = 1,
                    ProdutoFK = 1
                  },
                  new Existencias
                  {
                    IdExistencia = 2,
                    Quantidade = 12,
                    ClinicaFK = 1,
                    ProdutoFK = 2
                  },
                  new Existencias
                  {
                    IdExistencia = 3,
                    Quantidade = 5,
                    ClinicaFK = 1,
                    ProdutoFK = 3
                  },
                  new Existencias
                  {
                   IdExistencia = 4,
                   Quantidade = 10,
                   ClinicaFK = 1,
                   ProdutoFK = 4
                  },
                  new Existencias
                  {
                   IdExistencia = 5,
                   Quantidade = 5,
                   ClinicaFK = 2,
                   ProdutoFK = 1
                  },
                  new Existencias
                  {
                   IdExistencia = 6,
                   Quantidade = 3,
                   ClinicaFK = 2,
                   ProdutoFK = 2
                  },
                  new Existencias
                  {
                   IdExistencia = 7,
                   Quantidade = 2,
                   ClinicaFK = 2,
                   ProdutoFK = 3
                  },
                  new Existencias
                  {
                   IdExistencia = 8,
                   Quantidade = 2,
                   ClinicaFK = 2,
                   ProdutoFK = 4
                  }
                 );


        }
        #endregion Dados de Teste 

        public DbSet<Clinicas> Clinicas{ get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Existencias> Existencias { get; set; }
        public DbSet<Utilizadores> Utilizadores { get; set; }

    }
}
