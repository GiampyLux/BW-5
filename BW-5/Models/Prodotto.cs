using System.ComponentModel.DataAnnotations;

namespace clinica.Models
{
    public class Prodotto
    {
        [Key]
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