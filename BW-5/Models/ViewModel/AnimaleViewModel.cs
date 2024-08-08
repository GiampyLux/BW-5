﻿using BW_5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BW_5.Models.ViewModel
{
    public class AnimaleViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Razza { get; set; }

        [Required]
        [StringLength(30)]
        public string Pelo { get; set; }

        [Required]
        public DateTime Nascita { get; set; }

        [Required]
        public bool PossiedeMicrochip { get; set; }

        public string? NumeroMicrochip { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipologia { get; set; }  // Campo aggiunto

        [Required]
        [StringLength(50)]
        public string ColoreMantello { get; set; }  // Campo aggiunto

        public int IdProprietario { get; set; }
        public List<SelectListItem> Proprietario { get; set; } = new List<SelectListItem>();
        public Cliente? Proprietari { get; set; }
        public List<Visita> Anamnesi { get; set; } = new List<Visita>();
    }
}