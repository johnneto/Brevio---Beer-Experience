using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Brevio___Beer_Experience.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name ="Sobrenome")]
        public string sobrenome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome de Usuário")]
        public string login { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da Senha")]
        [Compare("Senha", ErrorMessage = "As senhas são diferentes.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }

    }
}