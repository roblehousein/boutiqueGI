namespace boutiqueGI.Models
{
    public class Produits
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required decimal Qt { get; set; }
        public DateTime DateExp { get; set; }
        public DateTime DateCrea { get; set; }
        public decimal Remise { get; set; } = 0;
        public bool Checked { get; set; } = false;
    }
}
