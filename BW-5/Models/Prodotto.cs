using BW_5.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW5.Models
{
    public class Prodotto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int IdDitta { get; set; }
        [ForeignKey("IdDitta")]
        public Ditta Ditta { get; set; }
        public int IdVendita { get; set; }
        public int IdMagazzino { get; set; }
        public string Utilizzo { get; set; }

    }
}
