namespace BW5.Models
{
    public class Ricovero
    {
        public int Id { get; set; }
        public int IdAnimale { get; set; }
        public Animale Animale { get; set; }
        public DateTime DataInizioRicovero { get; set; }
        public string Foto { get; set; }
    }
}
