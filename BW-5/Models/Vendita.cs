using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class Vendita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int ProdottoId { get; set; }

        [Required]
        public int NumeroRicetta { get; set; }

        public Cliente Cliente { get; set; }
        public Prodotto Prodotto { get; set; }
    }
}