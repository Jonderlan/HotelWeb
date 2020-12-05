using HotelWeb.DAL;
using HotelWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;

namespace HotelWeb.Controllers {
    //[Authorize(Roles = "ADM")]
    [Authorize]
    public class QuartoController : Controller {
        //https://getbootstrap.com/
        //https://bootswatch.com/
        //https://www.w3schools.com/bootstrap4/default.asp

        private readonly QuartoDAO _quartoDAO;
        private readonly TipoQuartoDAO _tipoQuartoDAO;
        private readonly IWebHostEnvironment _hosting;
        public QuartoController(QuartoDAO quartoDAO,
            IWebHostEnvironment hosting,
            TipoQuartoDAO tipoQuartoDAO) {
            _quartoDAO = quartoDAO;
            _tipoQuartoDAO = tipoQuartoDAO;
            _hosting = hosting;
        }
        //[AllowAnonymous]
        public IActionResult Index() {
            ViewBag.Title = "Gerenciamento de Quartos";
            return View(_quartoDAO.Listar());
        }
        public IActionResult Cadastrar() {
            ViewBag.TipoQuartos = new SelectList(_tipoQuartoDAO.Listar(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Quarto quarto, IFormFile file) {
            if (ModelState.IsValid) {
                if (file != null) {
                    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);
                    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));
                    quarto.Imagem = arquivo;

                } else {
                    quarto.Imagem = "semimagem.gif";

                }
                quarto.TipoQuarto = _tipoQuartoDAO.BuscarPorId(quarto.TipoQuartoId);
                if (_quartoDAO.Cadastrar(quarto)) {
                    return RedirectToAction("Index", "Quarto");
                }
                ModelState.AddModelError("", "Já existe um Quarto com o mesmo nome!");
            }
            ViewBag.TipoQuartos = new SelectList(_tipoQuartoDAO.Listar(), "Id", "Nome");
            return View(quarto);
        }
        public IActionResult Remover(int id) {
            _quartoDAO.Remover(id);
            return RedirectToAction("Index", "Quarto");
        }
 
        [HttpPost]
        public IActionResult Alterar(Quarto quarto) {
            _quartoDAO.Alterar(quarto);
            return RedirectToAction("Index", "Quarto");
        }
    }
}
