using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgettoFinale.Models
{
    public class Clienti
    {
        [Key]
        public int ClienteId { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string Cognome { get; set; } = string.Empty;

        [EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        
        [Phone ,MaxLength(16), MinLength(9)]
        public string Telefono { get; set; } = string.Empty;
    }
}
