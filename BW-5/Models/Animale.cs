using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinica.Models
{
    public class Animale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public string Nome { get; set; }
        public string Razza { get; set; }
        public string Pelo { get; set; }
        public DateTime Nascita { get; set; }
        public string Microchip { get; set; }
        public int IdProprietario { get; set; }
        public ICollection<Visita> Visite { get; set; }
        public ICollection<Ricovero> Ricoveri { get; set; }

    }
}
