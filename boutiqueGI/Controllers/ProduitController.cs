using boutiqueGI.Context;
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
                Update_Produit(param);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(string id)
        {
            using var context = new AppDbContext();
            var p = context.Produits.Where(i=>i.Id == id).FirstOrDefault();
            if (p != null)
                context.Produits.Remove(p);
            context.SaveChanges();
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
                using var context = new AppDbContext();
                context.Produits.Add(produit);
                context.SaveChanges();
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
                using var context = new AppDbContext();
                var produits = context.Produits.ToList();
                return produits;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void Update_Produit(Produits produits)
        {
            try
            {
                // update le produit using EntityFramework
                using var context = new AppDbContext();
                var p = context.Produits.Where(i => i.Id == produits.Id).FirstOrDefault();
                if (p != null)
                {
                    p.Name = produits.Name;
                    p.Price = produits.Price;
                    p.Qt = produits.Qt;
                    p.DateExp = produits.DateExp;
                    p.Remise = produits.Remise;
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
