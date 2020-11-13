using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers {
    public class ReservaController : Controller {

        private readonly Context _context;

        public ReservaController(Context context) {
            _context = context;
        }
        public IActionResult Index() => View();
        public IActionResult Reservar() => View();
        [HttpPost]
        public IActionResult Reservar(
            string txtNome, 
            string txtTipoQuarto, 
            string txtDtaEntrada, 
            string txtDtaSaida, 
            string txtQtdAdultos, 
            string txtQtdCriancas) {
            return RedirectToAction("Index","Reserva");
        }
        
    }
}
