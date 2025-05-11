using boutiqueGI.Context;
using boutiqueGI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace boutiqueGI.Controllers
{
    public class CommandeController : Controller
    {
        public IActionResult Index()
        {
            var commandeData = Get_Commande();
            return View(commandeData.OrderByDescending(d=>d.DateCommande));
        }

        public IActionResult Create()
        {
            var commandeData = new Commandes { Customers = Get_Client(), Produits = Get_Produit() };
            return View(commandeData);
        }

        [HttpPost]
        public IActionResult Create(Commandes commandes)
        {
            commandes.Panier = commandes.Produits!.Where(e => e.Checked == true).ToList();
            commandes.Total_Price = commandes.Panier.Sum(e => e.Price);
            commandes.DateCommande = DateTime.Now;
            commandes.Id = Guid.NewGuid();
            creation_commande(commandes);

            return RedirectToAction(nameof(Index));
        }

        private List<Produits> Get_Produit()
        {
            try
            {
                using var context = new AppDbContext();
                var produits = context.Produits.ToList();
                return produits;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Clients> Get_Client()
        {
            try
            {
                using var context = new AppDbContext();
                var clients = context.Clients.ToList();
                return clients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Commandes> Get_Commande()
        {
            try
            {
                using var context = new AppDbContext();
                var commandes = context.Commandes.
                    Include(c => c.CommandeLines)
                    .ThenInclude(cl => cl.produit)
                    .Include(c => c.Client)
                    .ToList();
                return commandes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void creation_commande(Commandes commande)
        {
            try
            {
                using var context = new AppDbContext();
                context.Commandes.Add(commande);
                foreach (var item in commande.Panier)
                {
                    var commandelie = new CommandeLine
                    {
                        Id = Guid.NewGuid(),
                        CommandesId = commande.Id,
                        ProduitsId = item.Id!,
                    };
                    context.CommandeLines.Add(commandelie);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
