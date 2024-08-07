using BW_5.Models;
using BW5.Models;
using Microsoft.EntityFrameworkCore;

namespace BW5.DataContext
{
    public class ClinicaDbContext : DbContext
    {
        public DbSet<Animale> Animali { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Visita> Visite { get; set; }
        public DbSet<Ricovero> Ricoveri { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }
        public DbSet<Magazzino> Magazzino { get; set; }
        public DbSet<Ditta> Ditta { get; set; }
        public DbSet<User> Users { get; set; }

        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurazione delle relazioni
            modelBuilder.Entity<Animale>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Animali)
                .HasForeignKey(a => a.IdProprietario)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurazioni aggiuntive se necessarie
        }
    }
}
