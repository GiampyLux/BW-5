using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BW5.Models
{
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVisita { get; set; }
        public int IdAnimale { get; set; }
        public DateTime DataVisita { get; set; }
        public string Esame { get; set; }
        public string DescrizioneCura { get; set; }
        public Animale Animale { get; set; }
    }
}
