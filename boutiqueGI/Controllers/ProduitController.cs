using boutiqueGI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace boutiqueGI.Controllers
{
   
    public class ProduitController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private List<Produits> produits;
        public ProduitController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            produits = new List<Produits>();
        }
        public IActionResult Index()
        {
            memoryCache.TryGetValue("produits", out produits!);
            return View(produits!);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            memoryCache.TryGetValue("produits", out produits!);
            var produit = produits.Where(p => p.Id == id).FirstOrDefault();

            return View(produit);
        }
        [HttpPost]
        public IActionResult Edit(Produits param)
        {
            if (ModelState.IsValid)
            {
                memoryCache.TryGetValue("produits", out produits!);
                var produit = produits.Where(p => p.Id == param.Id).FirstOrDefault();
                if (produit != null)
                {
                    produit.Name = param.Name;
                    produit.Price = param.Price;
                    produit.Qt = param.Qt;
                    produit.DateExp = param.DateExp;
                    produit.Remise = param.Remise;
                }
                memoryCache.Set("produits", produits);
                return RedirectToAction(nameof(Index));
            }
                return View();
        }
        
        public IActionResult Delete(string id)
        {
            memoryCache.TryGetValue("produits", out produits!);
            var produit = produits.Where(p => p.Id == id).FirstOrDefault();
            if (produit != null)
            {
                produits.Remove(produit);
            }
            memoryCache.Set("produits", produits);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Create(Produits produit)
        {
            if (ModelState.IsValid)
            {
                produit.Id = Guid.NewGuid().ToString();
                produit.DateCrea = DateTime.Now;
                memoryCache.TryGetValue("produits", out produits!);
                if(produits == null) { produits = new List<Produits>(); }
                produits!.Add(produit);
                memoryCache.Set("produits", produits);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
