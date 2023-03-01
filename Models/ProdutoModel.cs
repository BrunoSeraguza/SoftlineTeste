using System.ComponentModel.DataAnnotations;

namespace SoftLine.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a descricao do produto")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite o codigo de barras do produto")]
        public string CodigoDeBarras { get; set;}
        [Required(ErrorMessage = "Digite o valor da venda do produto")]
        public decimal valorVenda { get; set; }
        [Required(ErrorMessage = "Digite o peso bruto do produto")]
        public decimal PesoBruto { get; set; }
        [Required(ErrorMessage = "Digite o peso liquido do produto")]
        public decimal PesoLiquido { get; set; }


    }
}
