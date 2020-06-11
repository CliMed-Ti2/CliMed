using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        
        /// <summary>
        /// Nome do Funcionario
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(40)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
                 ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Nome { get; set; }

        /// <summary>
        /// Data de Nascimento Correspondente ao Funcionário
        /// </summary>
        /// 
        //TODO : REGEX + Add Date Pickers
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        /// <summary>
        /// Contacto do Funcionário 
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [RegularExpression("9[0-9]{8}", ErrorMessage = "O {0} deve ter 9 dígitos e começar por 9 ")]
        public string Contacto { get; set; }



        /// <summary>
        /// Email do Funcionário 
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Mail { get; set; }

        /// <summary>
        /// Nome da Morada do Funcionario
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(60)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | d[ao](s)? |-|'| d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+){1,3}",
            ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public string Morada { get; set; }


        /// <summary>
        /// Número do Cartão de Cidadão
        /// </summary>s
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(13)]
        [Display(Name = "Cartão Cidadão")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        public string CC { get; set; }


        /// <summary>
        /// Numero de Indentificação fiscal do Funcionário
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(9)]
        [Display(Name = "Número de Identificação Fiscal")]
        [RegularExpression("[0-9]{9}", ErrorMessage = "O {0} deve ter 9 dígitos.")]
        public string NIF { get; set; }


        /// <summary>
        /// Fotografia Correspondente ao Funcionário da Clinica
        /// </summary>
        public String Foto { get; set; }

        [Display(Name = "Clinica Pertencente")]
        //Chaves Estrangeiras
        [ForeignKey(nameof(Clinica))]
        public int ClinicaFK { get; set; }
        public Clinicas Clinica { get; set; }
    }
}