using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWeb.DAL;
using HotelWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers {
    public class ReservaController : Controller {

        private readonly ReservaDAO _reservaDAO;

        public ReservaController(ReservaDAO reservaDAO) => _reservaDAO = reservaDAO;

        public IActionResult Index() {

            List<Reserva> reservas = _reservaDAO.Listar();
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

            _reservaDAO.Cadastrar(reserva);
            return RedirectToAction("Index","Reserva");
        }

        public IActionResult Remover(int id) {

            _reservaDAO.Remover(id);
            return RedirectToAction("Index", "Reserva");    
        }
        public IActionResult Alterar(int id) {

            ViewBag.Reserva = _reservaDAO.BuscarPorId(id);
            return View(); 
        }

        [HttpPost]
        public IActionResult Alterar(
            int txtId,
            string txtNome,
            string txtTipoQuarto,
            DateTime txtDtaEntrada,
            DateTime txtDtaSaida,
            int txtQtdAdultos,
            int txtQtdCriancas) {
            Reserva reserva = _reservaDAO.BuscarPorId(txtId);
        
            reserva.Nome = txtNome;
            reserva.TipoQuarto = txtTipoQuarto;
            reserva.DataEntrada = txtDtaEntrada;
            reserva.DataSaida = txtDtaSaida;
            reserva.QuantosAdultos = txtQtdAdultos;
            reserva.QuantosCriancas = txtQtdCriancas;


            _reservaDAO.Alterar(reserva);
            return RedirectToAction("Index", "Reserva");
        }

    }
}
