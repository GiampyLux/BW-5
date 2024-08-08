﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdAnimale { get; set; }
        public DateTime DataVisita { get; set; }
        public string Esame { get; set; }
        public string DescrizioneCura { get; set; }
        [ForeignKey("IdAnimale")]
        public Animale Animale { get; set; }
    }
}
