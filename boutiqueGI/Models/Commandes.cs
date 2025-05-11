using System.ComponentModel.DataAnnotations.Schema;

namespace boutiqueGI.Models
{
    public class Commandes
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        [NotMapped]
        public  List<Produits>? Panier { get; set; }
        [NotMapped]
        public List<Produits>? Produits { get; set; }
        [NotMapped]
        public IEnumerable<Clients>? Customers { get; set; }
        public  Clients? Client { get; set; }
        public  string? ClientName { get; set; }
        public DateTime DateCommande { get; set; } = DateTime.Now;
        public Decimal Total_Price { get; set; } 
        public List<CommandeLine>? CommandeLines { get; set; }
    }
}
