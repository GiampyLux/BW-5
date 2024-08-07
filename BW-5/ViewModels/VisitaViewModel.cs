using System.ComponentModel.DataAnnotations;

namespace BW_5.ViewModels
{
    public class VisitaViewModel
    {
        public int Id { get; set; }
        public int AnimaleId { get; set; }
        public string NomeAnimale { get; set; } 
        public DateTime DataVisita { get; set; }
        public string Esame { get; set; }
        public string DescrizioneCura { get; set; }
    }
}
