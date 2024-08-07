using System.Collections.Generic;
using BW_5.Models;

namespace BW_5.Models.ViewModel
{
    public class AggiungiAlCarrelloViewModel
    {
        public int ClienteId { get; set; }
        public int ProdottoId { get; set; }
        public int NumeroRicetta { get; set; }
        public List<Prodotto> Prodotti { get; set; }
        public List<Vendita> Vendite { get; set; }
    }
}
