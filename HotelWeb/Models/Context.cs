using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models {
    public class Context : DbContext{

        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Quarto> Quartos { get; set; }

        public DbSet<Reserva> Reservas { get; set; }
    }
}
