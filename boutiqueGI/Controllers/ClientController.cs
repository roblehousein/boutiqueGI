using boutiqueGI.Context;
using boutiqueGI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace boutiqueGI.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            var clients = Get_Client();

            return View(clients);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Clients client)
        {
            if (ModelState.IsValid)
            {
                //definir un Id
                client.Id = Guid.NewGuid();
                //Enregistrer le client 
                creation_Client(client);
                //retourne vers la page client(index)
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(Guid id)
        {
            using var context = new AppDbContext();
            var client = context.Clients.Where(i => i.Id == id).FirstOrDefault();
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private void creation_Client(Clients client)
        {
            try
            {
                using var context = new AppDbContext();
                var p = context.Clients.Add(client);
                context.SaveChanges();
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
        
    }
}
