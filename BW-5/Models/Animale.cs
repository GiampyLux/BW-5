﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class Animale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Tipologia { get; set; }  // Campo aggiunto

        [Required]
        public string ColoreMantello { get; set; }  // Campo aggiunto

        [Required]
        public string Razza { get; set; }

        [Required]
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
