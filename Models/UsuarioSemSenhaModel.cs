using SoftLine.Enums;
using System.ComponentModel.DataAnnotations;

namespace SoftLine.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
       
        
      
    }
}
