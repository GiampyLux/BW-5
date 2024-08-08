using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class Cassetto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Armadio")]
        public int ArmadioId { get; set; }
        public Armadio Armadio { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
