namespace BW5.Models
{
    public class Animale
    {
        public int Id { get; set; }
        public DateTime dataRegistrazione { get; set; }
        public string Nome { get; set; }
        public string Tipologia { get; set; }
        public string ColorePelo {  get; set; }
        public DateTime DataNascita { get; set; }
        public string Microchip { get; set; }
        public string NomeProprietario { get; set; }
        public string CognomeProrietario { get; set; }
        public IEnumerable<Visita> Visite { get; set; }
        public IEnumerable<Ricovero> Ricoveri { get; set; }

    }
}
