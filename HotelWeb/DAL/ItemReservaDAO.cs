using HotelWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelWeb.DAL {
    public class ItemReservaDAO {
        private readonly Context _context;
        public ItemReservaDAO(Context context) => _context = context;
        public void Cadastrar(ItemReserva item) {
            _context.ItensReserva.Add(item);
            _context.SaveChanges();
        }
        public List<ItemReserva> ListarPorCarrinhoId(string id) =>
            _context.ItensReserva.AsNoTracking().
            Include(x => x.Quarto.TipoQuarto).
            Where(x => x.CarrinhoId == id).ToList();

        public double SomarTotalCarrinho(string id) =>
            ListarPorCarrinhoId(id).Sum(x => x.Quantidade * x.Preco);
    }   
}

