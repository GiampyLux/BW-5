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
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }
        [StringLength(16)]
        public string? CodiceFiscale { get; set; }
        public IEnumerable<Animale> Animali { get; set; }
        public IEnumerable<Vendita> Vendite { get; set; }
    }
}
