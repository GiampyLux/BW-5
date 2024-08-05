using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BW5.Models
{
    public class Animale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime dataRegistrazione { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Tipologia { get; set; }
        [Required]
        public string ColorePelo {  get; set; }
        [Required]
        public DateTime DataNascita { get; set; }
        public string Microchip { get; set; } 
        [Required]
        public int IdProprietario { get; set; }
        public IEnumerable<Visita> Visite { get; set; }
        public IEnumerable<Ricovero> Ricoveri { get; set; }

    }
}
