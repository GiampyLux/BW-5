using BW_5.Models;
using System.Collections.Generic;

namespace BW_5.Models.ViewModel
{
    public class VenditeClienteViewModel
    {
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; } // Reso nullable
        public List<Vendita> Vendite { get; set; } = new List<Vendita>(); // Inizializzato
        public List<Prodotto> Prodotti { get; set; } = new List<Prodotto>(); // Inizializzato
    }
}
