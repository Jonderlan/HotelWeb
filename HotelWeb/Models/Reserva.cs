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
        public string DataEntrada { get; set; }
        public string DataSaida { get; set; }
        public string QuantosAdultos { get; set; }
        public string QuantosCriancas { get; set; }




    }


}
