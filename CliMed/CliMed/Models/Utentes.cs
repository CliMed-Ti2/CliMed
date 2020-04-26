using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Utentes
    {

        /// <summary>
        /// Id do Utente 
        /// </summary>
        [Key]
        public int IdUtente { get; set; }

        /// <summary>
        /// Nome do Utente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(40)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Nome { get; set; }

        /// <summary>
        /// Data de Nascimento correspondente ao Utente
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }


        /// <summary>
        /// Contacto do Utente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [RegularExpression("9[0-9]{8}", ErrorMessage ="O {0} deve ter 9 dígitos e começar por 9 ")]
        public string Contacto { get; set; }

        /// <summary>
        /// Email correspondente ao Utente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        public string Mail { get; set; }

        /// <summary>
        /// Morada do Utente
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(60)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Morada { get; set; }

        /// <summary>
        /// Identificação do Cartão de Cidadão correspondente ao Utente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        [Display(Name = "Cartão Cidadão")]
        public string CC { get; set; }

        /// <summary>
        /// Numero de Indentificação Fiscal do Utente
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        [Display(Name = "Nº Identificação Fiscal")]
        public string NIF { get; set; }

    }
}
