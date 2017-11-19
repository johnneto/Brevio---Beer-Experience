using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.Models
{
    [Table("Familias")]
    public class Familia
    {
        [Key]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int usuario_id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime ult_modificacao { get; set; }
    }
}