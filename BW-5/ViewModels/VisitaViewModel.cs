using System.ComponentModel.DataAnnotations;

namespace BW_5.ViewModels
{
    public class VisitaViewModel
    {
        [Required]
        [Display(Name = "Data della Visita")]
        public DateTime DataVisita { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Esame Obiettivo")]
        public string EsameObiettivo { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descrizione della Cura")]
        public string DescrizioneCura { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome Animale")]
        public string NomeAnimale { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tipologia")]
        public string Tipologia { get; set; }

        [Required]
        [Display(Name = "Colore del Mantello")]
        public string ColorePelo { get; set; }

        [Required]
        [Display(Name = "Data di Nascita")]
        public DateTime DataNascita { get; set; }

        [Display(Name = "Microchip")]
        public string Microchip { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome Proprietario")]
        public string NomeProprietario { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Cognome Proprietario")]
        public string CognomeProprietario { get; set; }
        [Required]
        [StringLength(16)]
        [Display(Name = "Codice Fiscale")]
        public string CodiceFiscale { get; set; }
    }
}
