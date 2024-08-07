using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BW5.Models
{
    public class Ricovero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataRicovero { get; set; }
        public string Foto { get; set; }
        public int IdAnimale { get; set; }
        [ForeignKey("IdAnimale")]
        public Animale Animale { get; set; }
    }
}
