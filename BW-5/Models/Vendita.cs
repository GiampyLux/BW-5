using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class Vendita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }  // Modificato a nullable

        public int IdProdotto { get; set; }
        public Prodotto? Prodotto { get; set; }  // Modificato a nullable

        public int NumeroRicetta { get; set; }

        public DateTime DataVendita { get; set; }  // Campo aggiunto
    }
}