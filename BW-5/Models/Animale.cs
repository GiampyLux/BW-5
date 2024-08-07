using System.ComponentModel.DataAnnotations;
using BW_5.Models;

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
        public bool PossiedeMicrochip { get; set; }
        public string? NumeroMicrochip { get; set; }
        public int? IdProprietario { get; set; }
        [ForeignKey("IdProprietario")]
        public Cliente? Cliente { get; set; }
        public ICollection<Visita> Visite { get; set; }
        public ICollection<Ricovero> Ricoveri { get; set; }

    }
}
