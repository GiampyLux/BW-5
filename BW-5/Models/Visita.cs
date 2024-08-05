namespace BW5.Models
{
    public class Visita
    {
        public int Id { get; set; }
        public int IdAnimale { get; set; }
        public Animale Animale { get; set; }
        public DateTime DataVisita { get; set; }
        public string Esame {  get; set; }
        public string DescrizioneCure { get; set; }
    }
}
