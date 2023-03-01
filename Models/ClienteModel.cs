using System.ComponentModel.DataAnnotations;

namespace SoftLine.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite a Fantasia do cliente")]
        public string Fantasia { get; set;}
        [Required(ErrorMessage = "Digite o documento do cliente")]
        public string Documento { get; set;}
        [Required(ErrorMessage = "Digite o endereco do cliente")]
        public string Endereco { get; set;}
    }
}
