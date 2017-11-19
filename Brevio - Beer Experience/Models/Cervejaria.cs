using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.Models
{
    [Table("Cervejarias")]
    public class Cervejaria
    {
        [Key]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int usuario_id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "ZIP Code | CEP")]
        public string codigo { get; set; }

        [Display(Name = "País")]
        public string pais { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name ="Website")]
        public string website { get; set; }

        [Display(Name ="Descrição")]
        public string descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime ult_modificacao { get; set; }
    }
}