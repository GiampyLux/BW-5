using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BW5.Models
{
    public class Ricovero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdAnimale { get; set; }
        public Animale Animale { get; set; }
        [Required]
        public DateTime DataInizioRicovero { get; set; }
        public string Foto { get; set; }
    }
}
