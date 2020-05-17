using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Funcionarios
    {
        [Key]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(40)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [RegularExpression("9[1236][0-9]{7}", ErrorMessage = "O {0} deve ter 9 dígitos e começar por 9 ")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(13)]
        [Display(Name = "Cartão Cidadão")]
        public string CC { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [Display(Name = "Nº Identificação Fiscal")]
        [RegularExpression("[1-9][0-9]{9}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        public string NIF { get; set; }

      

    }
}
