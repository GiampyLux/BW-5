using BW_5.Models;
using BW_5.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BW_5.ViewModels
{
    public class AnimaleViewModel
    {
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

        public int IdProprietario { get; set; }
        public List<SelectListItem> Proprietari { get; set; } = new List<SelectListItem>();
        public Cliente? Proprietario { get; set; } 
        public List<Visita> Anamnesi { get; set; } = new List<Visita>();
    }
}
