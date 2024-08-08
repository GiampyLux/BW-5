using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BW_5.Models;

namespace BW_5.Models.ViewModel
{
    public class ProdottoVM

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Prodotto Prodotto { get; set; }
        public IEnumerable<Ditta> Ditte { get; set; }
        public IEnumerable<Cassetto> Cassetti { get; set; }
        public IEnumerable<Armadio> Armadi { get; set; }

        // Proprietà aggiuntive per il ViewModel
        public int Id => Prodotto?.Id ?? 0;
        public string Nome => Prodotto?.Nome;
        public string Tipo => Prodotto?.Tipo;
        public int DittaId => Prodotto?.DittaId ?? 0;
        public string Utilizzo => Prodotto?.Utilizzo;
        public int? ArmadioId => Prodotto?.ArmadioId;
        public int? CassettoId => Prodotto?.CassettoId;
        public Ditta Ditta => Prodotto?.Ditta;
        public Armadio Armadio => Prodotto?.Armadio;
        public Cassetto Cassetto => Prodotto?.Cassetto;
    }
}
