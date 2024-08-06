using BW_5.Models;
using BW5.Models;

namespace BW_5.ViewModels
{
    public class VenditaViewModel
    {
        public int ClienteId { get; set; }
        public List<Cliente> Clienti { get; set; }
        public int ProdottoId { get; set; }
        public List<Prodotto> Prodotti { get; set; }
        public string RicettaMedica { get; set; }
        public DateTime? DataVendita { get; set; }
    }
}
