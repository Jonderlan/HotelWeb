﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWeb.Models {
    [Table("Reservas")]
    public class Reserva : BaseModel {

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public string UsuarioId { get; set; }

        [ForeignKey("QuartoId")]
        public Quarto Quarto { get; set; }
        public int QuartoId { get; set; }

        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Observacao { get; set; }



    }
}
