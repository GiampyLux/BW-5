namespace clinica.Models
{
    public class Ditta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contatto { get; set; }
        public string Indirizzo { get; set; }
        public IEnumerable<Prodotto> Prodotti { get; set; }
    }
}
