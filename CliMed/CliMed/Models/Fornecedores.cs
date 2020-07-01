using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Fornecedores
    {
        [Key]
        public int idFornecedor { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        public String Designacao { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [Display(Name = "Nº Identificação Fiscal")]
        [RegularExpression("[1-9][0-9]{9}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        public String NIF { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(60)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public String Rua { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [RegularExpression("^[1-9]+[0-9]*$", ErrorMessage = "O campo deve ser preenchido com um numero inteiro positivo")]
        public int nPorta { get; set; }

        [StringLength(2)]
        [RegularExpression("[+][1-9]{1,2}[A-Z]{1}", ErrorMessage = "Exemplo de formato de preenchimento: 5A")]
        public String nAndar { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [RegularExpression ("[1-9][0-9]{3}-[0-9]{3}", ErrorMessage = "O campo deve ser preenchido com o formato xxxx-xxx")]
        [Display(Name = "Código Postal")]
        public String CodPostal { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(20)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public String Localidade { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [RegularExpression("9[1236][0-9]{7}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        public String Contacto { get; set; }


    }
}
