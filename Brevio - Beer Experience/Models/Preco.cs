using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.Models
{
    [Table("Precos")]
    public class Preco
    {
        [Key]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int usuario_id { get; set; }

        [ScaffoldColumn(false)]
        public int cerveja_id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Preço")]
        public float valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime dt_criacao { get; set; }
    }
}