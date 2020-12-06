using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWeb.Models {
    public class ItemReserva : BaseModel {
        public ItemReserva() => Quarto = new Quarto();

        [ForeignKey("QuartoId")]
        public Quarto Quarto { get; set; }
        public int QuartoId { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public string CarrinhoId { get; set; }
    }
}
