using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models {
    [Table("Quartos")]
    public class Quarto : BaseModel {

        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
