using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class Prodotto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Required]
        [MaxLength(200)]
        public string Utilizzo { get; set; }

        [ForeignKey("Ditta")]
        public int DittaId { get; set; }
        public Ditta Ditta { get; set; }

        [ForeignKey("Armadio")]
        public int? ArmadioId { get; set; }
        public Armadio Armadio { get; set; }

        [ForeignKey("Cassetto")]
        public int? CassettoId { get; set; }
        public Cassetto Cassetto { get; set; }
    }
}
