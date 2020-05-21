using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace CliMed.Models
{
    public class Existencias
    {
        public Existencias()
        {

        }
        /// <summary>
        /// Id da Existencia
        /// </summary>
        [Key]
        public int IdExistencia { get; set; }
        /// <summary>
        /// Indentificação da Quantidade
        /// </summary>
        /// ^\+?[1-9]\d*$
        [RegularExpression("^+?[1-9]d*$", ErrorMessage = "Só são aceites numeros positivos")]
        public int Quantidade { get; set; }
        /// <summary>
        /// Chave Estrangeira Existencias -> Clinica
        /// </summary>
        [Display(Name = "Clinica Pertencente")]
        [ForeignKey(nameof(Clinicas))]
        public int ClinicaFK { get; set; }
        public Clinicas Clinica { get; set; }
        /// <summary>
        /// Chave Estrangeira Existencias -> Clinica
        /// </summary>
        [Display(Name = "Clinica Pertencente")]
        [ForeignKey(nameof(Produtos))]
        public int ProdutoFK { get; set; }
        public Produtos Produto { get; set; }
    }
}