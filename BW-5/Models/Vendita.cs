namespace BW5.Models
{
    public class Vendita
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCognome { get; set; }
        public string ClienteCF { get; set; }
        public DateTime DataVendita { get; set; }
        public int ProdottoId { get; set; }
        public Prodotto Prodotto { get; set; }
        public string RicettaMedica { get; set; }

    }
}
