using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class Ricovero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DataInizio { get; set; }

        public DateTime? DataFine { get; set; }

        public string Foto { get; set; }

        public int IdAnimale { get; set; }

        [ForeignKey("IdAnimale")]
        public Animale Animale { get; set; }
    }
}
