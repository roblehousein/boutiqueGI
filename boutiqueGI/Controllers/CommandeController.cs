using boutiqueGI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace boutiqueGI.Controllers
{
    public class CommandeController : Controller
    {
        public IActionResult Index()
        {
            var commandeData = new Commandes {Customers = Get_Client(), Produits = Get_Produit()};
            return View(commandeData);
        }

        public IActionResult Create(Commandes commandes)
        {
            commandes.Panier = commandes.Produits!.Where(e=>e.Checked).ToList();
            commandes.Total_Price = commandes.Panier.Sum(e=>e.Price);
            commandes.DateCommande = DateTime.Now;
            creation_commande(commandes);
            commandes.Id= Guid.NewGuid();
            return RedirectToAction(nameof(Index));
        }

        private List<Produits> Get_Produit()
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "product.json";
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Dispose();
                }
                var contant = System.IO.File.ReadAllText(path);
                var produits = JsonConvert.DeserializeObject<List<Produits>>(contant);
                if (produits == null)
                {
                    produits = new List<Produits>();
                }
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
                var path = AppDomain.CurrentDomain.BaseDirectory + "client.json";
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Dispose();
                }
                var contant = System.IO.File.ReadAllText(path);
                var clients = JsonConvert.DeserializeObject<List<Clients>>(contant);
                if (clients == null)
                {
                    clients = new List<Clients>();
                }
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
                var path = AppDomain.CurrentDomain.BaseDirectory + "commandes.json";
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Dispose();
                }
                var contant = System.IO.File.ReadAllText(path);
                var commandes = JsonConvert.DeserializeObject<List<Commandes>>(contant);
                if (commandes == null)
                {
                    commandes = new List<Commandes>();
                }
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
                var path = AppDomain.CurrentDomain.BaseDirectory + "commandes.json";
                var contant = System.IO.File.ReadAllText(path);
                var commandes = JsonConvert.DeserializeObject<List<Commandes>>(contant);
                if (commandes == null)
                {
                    commandes = new List<Commandes>();
                }
                commandes.Add(commande);
                string json = JsonConvert.SerializeObject(commandes);
                System.IO.File.WriteAllText(path, json);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
