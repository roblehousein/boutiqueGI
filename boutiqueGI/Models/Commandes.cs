namespace boutiqueGI.Models
{
    public class Commandes
    {
        public Guid Id { get; set; }
        public required List<Produits> Produits { get; set; }
        public required Clients Client{ get; set; }
        public DateTime DateCommande { get; set; } = DateTime.Now;
    }
}
