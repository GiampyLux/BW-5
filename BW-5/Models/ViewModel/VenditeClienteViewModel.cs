
namespace clinica.Models.ViewModel
    {
    public class VenditeClienteViewModel
    {
        public List<Vendita> Vendite { get; set; } = new List<Vendita>(); // Inizializzazione della lista
        public List<Prodotto> Prodotti { get; set; } = new List<Prodotto>(); // Inizializzazione della lista
    }

}
