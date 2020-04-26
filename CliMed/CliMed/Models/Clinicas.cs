using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    /// <summary>
    /// Representa a tabela 'Clinica' na Base de Dados
    /// </summary>
    public class Clinicas
    {
        //inicializar lista de materiais
        public Clinicas()
        {
            ListaDeMateriais = new HashSet<Materiais>();
        }


        /// <summary>
        /// Id da Clinica
        /// </summary>
        [Key] 
        public int IdClinica { get; set; }

        /// <summary>
        /// Morada da Clinica
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(40)]
        public string Morada { get; set; }

        /// <summary>
        /// Contacto da Clinica
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [RegularExpression("9[0-9]{8}", ErrorMessage = "O {0} deve ter 9 dígitos e começar por 9 ")]
        public string Contacto { get; set; }

        /// <summary>
        /// Email da Clinica
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(30, ErrorMessage ="O {0} deve ter no máximo {1} caracteres.")]
        public string Mail { get; set; }

        /// <summary>
        /// Fotografia do Estabelecimento Clinica 
        /// </summary>
        [StringLength(15,ErrorMessage ="A {0} não deverá ter mais de {1} caracteres.")]
        public string Foto { get; set; }

        /// <summary>
        /// Lista de Materias de que a Clinica dispõe
        /// </summary>
        public ICollection<Materiais> ListaDeMateriais { get; set; }

    }
}
