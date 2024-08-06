using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BW5.Models
{
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IdAnimale { get; set; }
        [Required]
        public Animale Animale { get; set; }
        [Required]
        public DateTime DataVisita { get; set; }
        [Required]
        public string Esame { get; set; }
        [Required]
        public string DescrizioneCure { get; set; }
    }
}
