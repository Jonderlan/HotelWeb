﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HotelWeb.Models {
    public class BaseModel {

        public BaseModel() => CriadoEm = DateTime.Now;

        [Key]
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}