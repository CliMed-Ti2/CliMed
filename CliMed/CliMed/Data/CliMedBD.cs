using CliMed.Models;
using Microsoft.CodeAnalysis;
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



        }
        #endregion Dados de Teste 

        public DbSet<Clinicas> Clinicas{ get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Existencias> Existencias { get; set; }

    }
}
