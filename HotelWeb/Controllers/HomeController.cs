using HotelWeb.DAL;
using HotelWeb.Models;
using HotelWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace VendasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuartoDAO _quartoDAO;
        private readonly TipoQuartoDAO _tipoQuartoDAO;
        private readonly ItemReservaDAO _itemReservaDAO;
        private readonly Sessao _sessao;
        public HomeController(QuartoDAO quartoDAO,
            TipoQuartoDAO tipoQuartoDAO, ItemReservaDAO itemReservaDAO, Sessao sessao)
        {
            _quartoDAO = quartoDAO;
            _tipoQuartoDAO = tipoQuartoDAO;
            _itemReservaDAO = itemReservaDAO;
            _sessao = sessao;
        }
        public IActionResult Index(int id)
        {
            ViewBag.TipoQuartos = _tipoQuartoDAO.Listar();
            List<Quarto> quartos =
                id == 0 ?
                _quartoDAO.Listar() :
                _quartoDAO.ListarPorTipoQuarto(id);
            return View(quartos);
        }

        public IActionResult AdicionarAoCarrinho(int id)
        {
            Quarto quarto = _quartoDAO.BuscarPorId(id);
            ItemReserva item = new ItemReserva
            {
                Quarto = quarto,
                Preco = quarto.Preco,
                Quantidade = 1,
                CarrinhoId = _sessao.BuscarCarrinhoId()
            };
            _itemReservaDAO.Cadastrar(item);
            return RedirectToAction("CarrinhoCompras");
        }

        public IActionResult CarrinhoCompras()
        {
            ViewBag.Title = "Carrinho de compras";
            string carrinhoId = _sessao.BuscarCarrinhoId();
            ViewBag.Total = _itemReservaDAO.SomarTotalCarrinho(carrinhoId);
            return View(_itemReservaDAO.ListarPorCarrinhoId(carrinhoId));
        }
    }
}

//Ajustes e Funcionalidade novas do CARRINHO DE COMPRAS
//    - FEITO - Ajustar dados da tabela (Nome, imagem, preco, quantidade, subtotal e etc...);
//    - Caso o produto já exista no carrinho, alterar a sua quantidade;
//    - Adicionar links para aumentar e diminuir a quantidade do item;
//    - Adicionar um link para remover todo o item do carrinho;
//    - FEITO - Criar uma Viewbag para mostrar o total do carrinho;
//    - Criar um link na barra de navegação para abrir o carrinho de compras;
//    - Mostrar a quantidade de itens dentro do carrinho na barra de navegação;
//    - Um para finalizar a compra;
