using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Models {
    public class Context : IdentityDbContext<Usuario> {

        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Quarto> Quartos { get; set; }

        public DbSet<TipoQuarto> TipoQuartos { get; set; }

        public DbSet<ItemReserva> ItensReserva { get; set; }

        public DbSet<UsuarioView> Usuarios { get; set; }
    }
}
