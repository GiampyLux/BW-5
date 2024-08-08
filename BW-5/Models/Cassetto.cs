using System.ComponentModel.DataAnnotations;

namespace BW_5.Models
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