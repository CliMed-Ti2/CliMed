using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace CliMed.Models
{
    public class Produtos
    {
        /// <summary>
        /// Id correspondente ao Produto
        /// </summary>
        [Key]
        public int IDProduto { get; set; }
        /// <summary>
        /// Designação do Produto
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        [Display(Name = "Designação")]
        public string Designacao { get; set; }
        /// <summary>
        /// Indentificação do Tipo de Material - Consumivel...
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public string Tipo { get; set; }
        /// <summary>
        /// Foto do Produto
        /// </summary>
        public String Foto { get; set; }
        /// <summary>
        /// Chaves Estrangeiras Materias -> Clinica
        /// </summary>
        [Display(Name = "Clinica Pertencente")]
        [ForeignKey(nameof(Clinica))]
        public int ClinicaFK { get; set; }
        public Clinicas Clinica { get; set; }
    }
}