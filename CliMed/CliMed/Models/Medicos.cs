using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Medicos
    {
        // inicializar lista de consultas do Médico
        public Medicos()
        {
            ListaDeConsultas = new HashSet<Consultas>();
        }

        /// <summary>
        /// ID do Médico
        /// </summary>
        [Key]
        public int idMedico { get; set; }

        /// <summary>
        /// Numero de identificação do Médico
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}", ErrorMessage = "O campo deverá ser preenchido com 16 dígitos, separados de 4 em 4 por um espaço")]
        public string nCedula { get; set; }

        /// <summary>
        /// Nome do Médico
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(40)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
        ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        [Display(Name = "Nº da Cédula Profissional")]
        public string Nome { get; set; }

        /// <summary>
        /// Data de Nascimento do Médico
        /// </summary>
        [Required(ErrorMessage ="A {0} é de preenchimento obrigatório!")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNasc { get; set; }

        /// <summary>
        /// Anos de Experiência do Médico
        /// </summary>
        [RegularExpression("[0-50]{2}", ErrorMessage = "Os {0} deve ser um número positivo até 50")]
        [Display(Name = "Anos de Experiência")]
        public int AnosExp { get; set; }

        /// <summary>
        /// Contacto correspondente ao Médico
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [RegularExpression("9[0-9]{8}", ErrorMessage = "O {0} deve ter 9 dígitos e começar por 9 ")]
        public string Contacto { get; set; }


        /// <summary>
        /// Email Pessoal do Médico , pertencente a clinica
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        public string Mail { get; set; }


        /// <summary>
        /// Morada do Médico
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(60)]
        public string Morada { get; set; }

        /// <summary>
        /// Numero do Cartão de Cidadão do Médico
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [Display(Name = "Cartão Cidadão")]
        public string CC { get; set; }


        /// <summary>
        /// Numero de Identificação Fiscal correspondente ao Médico
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [Display(Name = "Nº Identificação Fiscal")]
        public string NIF { get; set; }

        /// <summary>
        /// Lista de Consultas a que o médico está associado
        /// </summary>
        public ICollection<Consultas> ListaDeConsultas { get; set; }

    }
}
