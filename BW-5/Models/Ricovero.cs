using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BW5.Models
{
    public class Ricovero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRicovero { get; set; }
        public DateTime DataRicovero { get; set; }
        public string Foto { get; set; }
        public int IdAnimale { get; set; }
        public Animale Animale { get; set; }
    }
}
