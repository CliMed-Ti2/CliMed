using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CliMed.Models
{
    public class Materiais
    {

        /// <summary>
        /// Id correspondente ao Material
        /// </summary>
        [Key]
        public int IdMaterial { get; set; }

        /// <summary>
        /// Descrição do Material
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(30)]
        public string Descricao { get; set; }

        /// <summary>
        /// Indicação do Stock existente do Material
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        public int Stock { get; set; }

        /// <summary>
        /// Indentificação do Tipo de Material - Medicamento , Consumivel
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        public string Tipo { get; set; }

        /// <summary>
        /// Preco de Compra do Respectivo Material
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [Display(Name = "Preço de Compra")]
        public float PrecoCompra { get; set; }

        /// <summary>
        /// Preco de Venda Do Material
        /// </summary>
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório")]
        [Display(Name = "Preço de Comercialização")]
        public float precoVenda { get; set; }

        /// <summary>
        /// Chaves Estrangeiras Materias -> Clinica
        /// </summary>
        [Display(Name = "Clinica Pertencente")]
        [ForeignKey(nameof(Clinica))]
        public int ClinicaFK { get; set; }
        public Clinicas Clinica { get; set; }

    }
}
