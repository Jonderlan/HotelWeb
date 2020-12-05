using HotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.DAL {
    public class TipoQuartoDAO {
        private readonly Context _context;
        public TipoQuartoDAO(Context context) => _context = context;
        public List<TipoQuarto> Listar() => _context.TipoQuartos.ToList();
        public TipoQuarto BuscarPorId(int id) => _context.TipoQuartos.Find(id);
    }
}
