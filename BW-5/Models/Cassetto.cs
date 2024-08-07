using System.ComponentModel.DataAnnotations;

namespace clinica.Models
{
    public class Cassetto
    {

        [Key]
        public int Id { get; set; }

        public int Name { get; set; }
        public int ArmadioId { get; set; }

        public Armadio Armadio { get; set; }
    }
}