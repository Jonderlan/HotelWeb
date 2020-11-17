using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers {
    public class ReservaController : Controller {

        private readonly Context _context;

        public ReservaController(Context context) => _context = context;

        public IActionResult Index() {

            List<Reserva> reservas = _context.Reservas.ToList();
            ViewBag.Reservas = reservas;
            ViewBag.QuantidadeReservas = reservas.Count();
            ViewBag.DataHora = DateTime.Now;
            return View();
        }
        public IActionResult Reservar() => View();
        [HttpPost]
        public IActionResult Reservar(
            string txtNome, 
            string txtTipoQuarto, 
            DateTime txtDtaEntrada, 
            DateTime txtDtaSaida, 
            int txtQtdAdultos, 
            int txtQtdCriancas) {
            Reserva reserva = new Reserva {
                Nome = txtNome,
                TipoQuarto = txtTipoQuarto,
                DataEntrada = txtDtaEntrada,
                DataSaida = txtDtaSaida,
                QuantosAdultos = txtQtdAdultos,
                QuantosCriancas = txtQtdCriancas
            };

            _context.Reservas.Add(reserva);
            _context.SaveChanges();
            return RedirectToAction("Index","Reserva");
        }

        public IActionResult Remover(int id) {

            //Completar com o código da remoção.
            return RedirectToAction("Index", "Reserva");
        }
        
    }
}
