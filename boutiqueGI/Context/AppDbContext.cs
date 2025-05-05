using Microsoft.EntityFrameworkCore;

namespace boutiqueGI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Produits> Produits { get; set; }
        public DbSet<Models.Clients> Clients { get; set; }
      //  public DbSet<Models.Commandes> Commandes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=boutique;User=root;Password=;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        
    }
}
