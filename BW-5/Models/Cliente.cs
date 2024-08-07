using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BW5.Models;

namespace BW_5.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty; // Inizializzazione con valore predefinito

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; } = string.Empty; // Inizializzazione con valore predefinito

        [Required]
        [StringLength(16)]
        public string CodiceFiscale { get; set; } = string.Empty; // Inizializzazione con valore predefinito

        public IEnumerable<Animale> Animali { get; set; } = new List<Animale>(); // Inizializzazione con valore predefinito

        public IEnumerable<Vendita> Vendite { get; set; } = new List<Vendita>(); // Inizializzazione con valore predefinito
    }
}