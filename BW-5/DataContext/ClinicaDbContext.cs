using BW_5.Models;
using BW5.Models;
using Microsoft.EntityFrameworkCore;

namespace BW5.DataContext
{
    public class ClinicaDbContext : DbContext
    {
        public DbSet<Animale> Animali {  get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Visita> Visite {  get; set; }
        public DbSet<Ricovero> Ricoveri { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }
        public DbSet<Armadio> Armadi { get; set; }
        public DbSet<Cassetto> Cassetti { get; set; }
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> opt) : base(opt) { }

    }
}
