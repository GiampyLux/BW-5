using BW5.Models;

namespace BW_5.Models
{
    public class Ditta
    {
        public int IdDitta { get; set; }
        public string Nome { get; set; }
        public string Contatto { get; set; }
        public string Indirizzo { get; set; }
        public IEnumerable<Prodotto> Prodotti { get; set; }
    }
}
