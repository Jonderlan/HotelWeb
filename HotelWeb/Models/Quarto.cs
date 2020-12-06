using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWeb.Models {
    [Table("Quartos")]
    public class Quarto : BaseModel {
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Preco { get; set; }
        public string Imagem { get; set; }

        [ForeignKey("TipoQuartoId")]
        public TipoQuarto TipoQuarto { get; set; }
        public int TipoQuartoId { get; set; }
    }
}
