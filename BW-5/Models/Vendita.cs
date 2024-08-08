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
        public Cliente Cliente { get; set; }
        public int IdProdotto { get; set; }
        public int NumeroRicetta { get; set; }
        public Prodotto Prodotto { get; set; }

    }
}
