using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Medicos
    {

        [ForeignKey(nameof(Funcionarios))]
        [Key]
        public int idMedico { get; set; }
        public Funcionarios Funcionario { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [Display(Name = "Nº da Cédula Profissional")]
        [RegularExpression("[1-9][0-9]{3,4}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        public String nCedula{ get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [Display(Name = "Anos de Experiência")]
        [RegularExpression("[1-40]{1}")]
        public int anosExp { get; set; }


    }
}
