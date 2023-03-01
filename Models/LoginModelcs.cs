using System.ComponentModel.DataAnnotations;

namespace SoftLine.Models
{
    public class LoginModelcs
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }
    }
}
