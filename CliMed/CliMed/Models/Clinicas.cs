using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CliMed.Models
{
    /// <summary>
    /// Representa a tabela 'Clinica' na Base de Dados
    /// </summary>
    public class Clinicas
    {
        //inicializar lista de materiais
        public Clinicas()
        {

        }
        /// <summary>
        /// Id da Clinica
        /// </summary>
        [Key]
        public int IdClinica { get; set; }
        /// <summary>
        /// Identificação da Rua onde a Clinica Existe
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(60)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]", ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public String Rua { get; set; }
        /// <summary>
        /// Identificação do Numero da Porta da Clinica
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Numero da Porta")]
        public int nPorta { get; set; }
        /// <summary>
        /// Numero de Andar da Clinica (Opcional ou não ) -> Restrição Exemplo "5D"
        /// </summary>
        [Display(Name = "Numero da Andar")]
        [StringLength(3)]
        [RegularExpression("[+][1-9]{1,2}[A-Z]{1}", ErrorMessage = "Exemplo de formato de preenchimento: 3D")]
        public String nAndar { get; set; }
        /// <summary>
        /// Codigo Postal da Clinica
        /// </summary>
        [Required]
        [RegularExpression("[1-9][0-9]{3}-[0-9]{3}", ErrorMessage = "Deve inicialmente introduzir quatro numeros,sendo o primeiro de 1-9 e os restantes de 0-9, de seguida separar por tracinho(-) e por ultimo prencher três números de 0-9")]
        [StringLength(8)]
        [Display(Name = "Codigo Postal")]
        public String CodPostal { get; set; }
        /// <summary>
        /// Localidade onde a clinica reside
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(20)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]", ErrorMessage = "Só são aceites nomes, começados por letra Maiúscula, separados entre si por um espaço em branco.")]
        public String Localidade { get; set; }
        /// <summary>
        /// Numero de Indentificação Fiscal da Clinca
        /// </summary>
        ///
        [Display(Name = "Número dsse Identificação Fiscal")]
        [StringLength(9)]
        [RegularExpression("[1-9][0-9]{8}", ErrorMessage = "Deverá introduzir o NIF corretamente, contendo 9 numeros")]
        public string NIF { get; set; }
        /// <summary>
        /// Contacto da Clinica
        /// </summary>
        [StringLength(9)]
        [RegularExpression("9[0-9]{8}", ErrorMessage = "O {0} deve ter 9 dígitos e começar por 9 ")]
        public String Contacto { get; set; }
        /// <summary>
        /// Email correspondente a Clinica
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EMail { get; set; }
        /// <summary>
        /// Foto da Clinica
        /// </summary>
        public String Foto { get; set; }
    }
}