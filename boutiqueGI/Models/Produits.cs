using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boutiqueGI.Models
{
    public class Produits
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(50,MinimumLength =10, ErrorMessage = "Le nom doit etre au minimum 10 et ne as dépasser 50 caractères")]
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required decimal Qt { get; set; }
        public DateTime DateExp { get; set; }
        public DateTime DateCrea { get; set; }
        public decimal Remise { get; set; } = 0;
        [NotMapped]
        public bool Checked { get; set; } = false;
    }
}
