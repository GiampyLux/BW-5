using BW_5.Models;
using System.Collections.Generic;

namespace BW_5.ViewModel
{
    public class VenditeClienteViewModel
    {
        public int ClienteId { get; set; }
        public List<Vendita> Vendite { get; set; }
        public List<Prodotto> Prodotti { get; set; }  // Aggiunta la proprietà Prodotti
    }
}
