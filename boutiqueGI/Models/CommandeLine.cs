namespace boutiqueGI.Models
{
    public class CommandeLine
    {
        public Guid Id { get; set; }
        public Guid CommandesId { get; set; }
        public string ProduitsId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Produits? produit { get; set; }
        public Commandes? commande { get; set; }

    }
}
