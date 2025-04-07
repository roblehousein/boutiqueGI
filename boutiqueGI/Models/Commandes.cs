namespace boutiqueGI.Models
{
    public class Commandes
    {
        public Guid Id { get; set; }
        // liste des produits vendus
        public  List<Produits>? Panier { get; set; }
        // liste des produits en stock
        public List<Produits>? Produits { get; set; }
        // liste des clients déjà enregistrer
        public IEnumerable<Clients>? Customers { get; set; }
        public  Clients? Client { get; set; }
        //nom du client qui a passé la commande
        public  string? ClientName { get; set; }
        public DateTime DateCommande { get; set; } = DateTime.Now;
        public Decimal Total_Price { get; set; } 
    }
}
