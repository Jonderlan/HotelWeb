using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models {

    [Table ("Reservas")]
    public class Reserva : BaseModel {

        public string Nome { get; set; }
        public string TipoQuarto { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public int QuantosAdultos { get; set; }
        public int QuantosCriancas { get; set; }




    }


}
