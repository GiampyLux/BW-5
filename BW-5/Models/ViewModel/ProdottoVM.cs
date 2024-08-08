
            using System.Collections.Generic;
        using BW_5.Models;

namespace BW_5.Models.ViewModel
    {
        public class ProdottoVM
        {
            public Prodotto Prodotto { get; set; }
            public IEnumerable<Ditta> Ditte { get; set; }
            public IEnumerable<Cassetto> Cassetti { get; set; }
            public IEnumerable<Armadio> Armadi { get; set; }
            public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int IdDitta { get; set; }
        public string Utilizzo { get; set; }
        public int? ArmadioId { get; set; }
        public int? CassettoId { get; set; }
        public Ditta? Ditta { get; set; }
        public Armadio armadio { get; set; }
        public Cassetto Cassetto { get; set; }
    }


}
