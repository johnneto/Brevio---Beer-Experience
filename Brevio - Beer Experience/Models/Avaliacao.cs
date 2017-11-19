using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.Models
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int usuario_id { get; set; }

        [ScaffoldColumn(false)]
        public int cerveja_id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Qualidade")]
        public int nota_qualidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Custo")]
        public int nota_custo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Sabor")]
        public int nota_sabor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Apresentação")]
        public int nota_apresentacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Harmonização")]
        public int nota_harmonizacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nota Geral")]
        public int nota_geral { get; set; }

        [MaxLength(240, ErrorMessage = " No máximo 240 caracteres")]
        [Display(Name = "Comentário")] 
        public string comentario { get; set; }

        [ScaffoldColumn(false)]
        public DateTime dt_criacao { get; set; }
    }
}