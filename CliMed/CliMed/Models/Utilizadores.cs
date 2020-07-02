using CliMed.Data;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CliMed.Models
{
    public class Utilizadores
    {

        /// <summary>
        /// Id que idenfica o Utilizador
        /// </summary>
        [Key]
        public int idUtilizador { get; set; }


        /// <summary>
        /// Nome do Utilizador
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(25)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
        ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Nome { get; set; }


        /// <summary>
        /// Localidade do Utilizador
        /// </summary>
        /// <summary>
        /// Localidade onde a clinica reside
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(20)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]{3,18}",
            ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public String Localidade { get; set; }


        /// <summary>
        /// Código Postal do Utilizador
        /// </summary>
        [RegularExpression("[1-9][0-9]{3}-[0-9]{3}", ErrorMessage = "Deve inicialmente introduzir quatro números,sendo o primeiro de 1-9 e os restantes de 0-9, de seguida separar por tracinho(-) e por ultimo preencher três números de 0-9")]
        [StringLength(8)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }


        /// <summary>
        /// Contacto correspondente ao Utilizador
        /// </summary>
        [StringLength(9)]
        [RegularExpression("9[0-9]{8}", ErrorMessage = "O {0} deve ter 9 dígitos e começar por 9 ")]
        public string Contacto { get; set; }


        /// <summary>
        /// Email pessoal do Utilizador
        /// </summary>
        [Required]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O E-mail inserido não é Válido")]
        public string Email { get; set; }


        /// <summary>
        /// Fotografia , idenficativa do Utilizador
        /// </summary>
        public string Fotografia { get; set; }


        /// <summary>
        /// Atributo que indica o Utilizador que se Autentica.
        /// Pode ser Intepretada como uma Foreign Key,
        /// apesar de não ser definda de uma forma expressa
        /// </summary>
        public string UserID { get; set; }

    }
}
