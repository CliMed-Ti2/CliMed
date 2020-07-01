using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Administradores
    {
        [ForeignKey(nameof(Funcionarios))]
        [Key]
        public int idAmin { get; set; }
        public Funcionarios Funcionario { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [Display(Name = "Área de Especialidade")]
        public String AreaEsp { get; set; }


     

    }
}
