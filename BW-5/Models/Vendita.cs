using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BW_5.Models;

namespace BW5.Models
{
    public class Vendita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string NumeroRicetta { get; set; }
        public Prodotto Prodotto { get; set; }

    }
}
