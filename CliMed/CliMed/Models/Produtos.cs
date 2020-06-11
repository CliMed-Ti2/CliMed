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
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
            ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]

        public string Designacao { get; set; }


        /// <summary>
        /// Indentificação do Tipo de Material - Consumivel...
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
            ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
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