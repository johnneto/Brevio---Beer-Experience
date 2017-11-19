using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.Models
{
    [Table("Cervejas")]
    public class Cerveja
    {
        [Key]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int cervejaria_id { get; set; }

        [ScaffoldColumn(false)]
        public int usuario_id { get; set; }

        [ScaffoldColumn(false)]
        public int estilo_id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name ="ABV - Alcool por Volume")]
        public float abv { get; set; }

        [Display(Name ="IBU - Teor de Amargura")]
        public float ibu { get; set; }

        [Display(Name ="SRM - Escala de Coloração")]
        public float srm { get; set; }

        [Display(Name ="Descrição")]
        public string descricao { get; set; }

        [Display(Name ="Imagem")]
        public string img { get; set; }

        [ScaffoldColumn(false)]
        public DateTime ult_modificacao { get; set; }
        

    }
}