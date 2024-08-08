using BW_5.Models;
using Microsoft.EntityFrameworkCore;


namespace BW_5.DataContext
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animale> Animali { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Visita> Visite { get; set; }
        public DbSet<Ricovero> Ricoveri { get; set; }
        public DbSet<Prodotto> Prodotti { get; set; }
        public DbSet<Vendita> Vendite { get; set; }
        public DbSet<Armadio> Armadi { get; set; }
        public DbSet<Cassetto> Cassetti { get; set; }
        public DbSet<Ditta> Ditte { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships for Prodotto entity
            modelBuilder.Entity<Prodotto>()
                .HasOne(p => p.Ditta)
                .WithMany()  // Assumes Ditta does not have a collection of Prodotti
                .HasForeignKey(p => p.IdDitta)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


            modelBuilder.Entity<Ditta>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Vendita>()
             .HasIndex(v => new { v.ClienteId, v.ProdottoId, v.NumeroRicetta })
             .IsUnique();
        }
    }
}