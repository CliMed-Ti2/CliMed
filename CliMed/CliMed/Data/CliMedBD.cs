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
            ;





            /*modelBuilder.Entity<Funcionarios>().HasData(
                 new Funcionarios
                 {


                 }
                );*/



        }
        #endregion Dados de Teste 

        public DbSet<Clinicas> Clinicas{ get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Existencias> Existencias { get; set; }

    }
}
