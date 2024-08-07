using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinica.Models
{
    public class Ricovero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataRicovero { get; set; }
        public string Foto { get; set; }
        public int IdAnimale { get; set; }
        public Animale Animale { get; set; }
    }
}
