using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_5.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Il nome deve essere tra 3 e 50 caratteri.")]
        public required string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Inserisci un indirizzo email valido.")]
        public required string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La password deve essere almeno di 6 caratteri.")]
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
