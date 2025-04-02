using boutiqueGI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace boutiqueGI.Controllers
{

    public class ProduitController : Controller
    {

        private List<Produits> produits;
        public ProduitController()
        {
            produits = new List<Produits>();
        }
        public IActionResult Index()
        {
            var produits = Get_Produit();
            return View(produits!);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            var produits = Get_Produit();

            var produit = produits.Where(p => p.Id == id).FirstOrDefault();

            return View(produit);
        }
        [HttpPost]
        public IActionResult Edit(Produits param)
        {
            if (ModelState.IsValid)
            {
                var produits = Get_Produit();
                var produit = produits.Where(p => p.Id == param.Id).FirstOrDefault();
                if (produit != null)
                {
                    produit.Name = param.Name;
                    produit.Price = param.Price;
                    produit.Qt = param.Qt;
                    produit.DateExp = param.DateExp;
                    produit.Remise = param.Remise;
                };
                Update_Produit(produits);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            var produits = Get_Produit();
            var produit = produits.Where(p => p.Id == id).FirstOrDefault();
            if (produit != null)
            {
                produits.Remove(produit);
            }
            Update_Produit(produits);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(string id)
        {
            var produits = Get_Produit();
            var produit = produits.Where(p => p.Id == id).FirstOrDefault();
           
            return View(produit);
        }

        [HttpPost]
        public IActionResult Create(Produits produit)
        {
            if (ModelState.IsValid)
            {
                produit.Id = Guid.NewGuid().ToString();
                produit.DateCrea = DateTime.Now;
                creation_Produit(produit);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private void creation_Produit(Produits produit)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "product.json";
                var contant = System.IO.File.ReadAllText(path);
                var produits = JsonConvert.DeserializeObject<List<Produits>>(contant);
                if (produits == null)
                {
                    produits = new List<Produits>();
                }
                produits.Add(produit);
                string json = JsonConvert.SerializeObject(produits);
                System.IO.File.WriteAllText(path, json);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        private void Update_Produit(List<Produits> produits)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "product.json";
                string json = JsonConvert.SerializeObject(produits);
                System.IO.File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
