using System.ComponentModel.DataAnnotations;
using BW_5.Models;

namespace BW_5.ViewModel
{
    public class VisitaViewModel
    {
        public int Id { get; set; }
        public int IdAnimale { get; set; }
        public string NomeAnimale { get; set; }
        public DateTime DataVisita { get; set; }
        public string Esame { get; set; }
        public string DescrizioneCura { get; set; }
    }
}
