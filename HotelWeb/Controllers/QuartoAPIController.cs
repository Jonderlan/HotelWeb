using HotelWeb.DAL;
using HotelWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelWeb.Controllers {

    [Route("api/Quarto")]
    [ApiController]
    public class QuartoAPIController : ControllerBase {
        //Postman
        //Insomnia
        //VS Code - RestClient
        private readonly QuartoDAO _quartoDAO;
        public QuartoAPIController(QuartoDAO quartoDAO) {
            _quartoDAO = quartoDAO;
        }

        //GET: /api/Quarto/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar() {
            List<Quarto> quartos = _quartoDAO.Listar();
            if (quartos.Count > 0) {
                return Ok(quartos);
            }
            return BadRequest(new { msg = "Lista de quartos vazia!" });
        }

        //GET: /api/Quarto/Buscar/1
        [HttpGet]
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id) {
            Quarto quarto = _quartoDAO.BuscarPorId(id);
            if (quarto != null) {
                return Ok(quarto);
            }
            return NotFound(new { msg = "Quarto não encontrado!" });
        }



        //POST: /api/Quarto/Cadastrar/
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Quarto quarto) {
            if (ModelState.IsValid) {
                if (_quartoDAO.Cadastrar(quarto)) {
                    return Created("", quarto);
                }
                return Conflict(new { msg = "Esse quarto já existe!" });
            }
            return BadRequest(ModelState);
        }
    }
}
