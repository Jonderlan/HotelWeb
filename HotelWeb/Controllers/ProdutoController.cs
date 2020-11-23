using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWeb.DAL;
using HotelWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers {
    public class ProdutoController : Controller {

        private readonly ProdutoDAO _produtoDAO;

        public ProdutoController(ProdutoDAO produtoDAO) => _produtoDAO = produtoDAO;

        public IActionResult Index() {

            List<Produto> produtos = _produtoDAO.Listar();
            ViewBag.Produtos = produtos;
            ViewBag.QuantidadeProdutos = produtos.Count();
            ViewBag.DataHora = DateTime.Now;
            return View();
        }
        public IActionResult Cadatrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(
            string txtNome,
            string txtDescricao,
            int txtQuantidade,
            double txtPreco) {
            Produto produto = new Produto {
                Nome = txtNome,
                Descricao = txtDescricao,
                Quantidade = txtQuantidade,
                Preco = txtPreco
            };
          
            if(_produtoDAO.Cadastrar(produto)) {
              return RedirectToAction("Index", "Produto");
            }
            return View(); 
 
        }

        public IActionResult Remover(int id) {

            _produtoDAO.Remover(id);
            return RedirectToAction("Index", "Produto");
        }
        public IActionResult Alterar(int id) {

            ViewBag.Produto = _produtoDAO.BuscarPorId(id);
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(
            int txtId,
            string txtNome,
            string txtDescricao,
            int txtQuantidade,
            double txtPreco) {
            Produto produto = _produtoDAO.BuscarPorId(txtId);
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Quantidade = txtQuantidade;
            produto.Preco = txtPreco;


            _produtoDAO.Alterar(produto);
            return RedirectToAction("Index", "Produto");
        }

    }
}
