using HotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.DAL {
    public class ReservaDAO {

        private readonly Context _context;
        public ReservaDAO(Context context) => _context = context;

        public List<Reserva> Listar() => _context.Reservas.ToList();

        public Reserva BuscarPorId(int id) => _context.Reservas.Find(id);
        public void Cadastrar(Reserva reserva) {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }
        public void Remover(int id) {
            _context.Reservas.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
        public void Alterar(Reserva reserva) {
            _context.Reservas.Update(reserva);
            _context.SaveChanges();
        }
    }
}
