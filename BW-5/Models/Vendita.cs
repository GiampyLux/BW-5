using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BW5.Models
{
    public class Vendita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public DateTime DataVendita { get; set; }
        [Required]
        public int ProdottoId { get; set; }
        public Prodotto Prodotto { get; set; }
        public string RicettaMedica { get; set; }

    }
}
