using HotelWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.DAL {
    public class QuartoDAO {
        private readonly Context _context;
        public QuartoDAO(Context context) => _context = context;
        public List<Quarto> Listar() =>
            _context.Quartos.Include(x => x.TipoQuarto).ToList();
        public Quarto BuscarPorId(int id) => _context.Quartos.Find(id);
        public Quarto BuscarPorNome(string nome) =>
            _context.Quartos.FirstOrDefault(x => x.Nome == nome);
        public List<Quarto> ListarPorTipoQuarto(int id) =>
            _context.Quartos.Where(x => x.TipoQuartoId == id).ToList();
        public bool Cadastrar(Quarto quarto) {
            if (BuscarPorNome(quarto.Nome) == null) {
                _context.Quartos.Add(quarto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Remover(int id) {
            _context.Quartos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Quarto quarto) {
            _context.Quartos.Update(quarto);
            _context.SaveChanges();
        }
    }
}
