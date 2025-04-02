using boutiqueGI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace boutiqueGI.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private void creation_Client(Clients client)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "client.json";
                var contant = System.IO.File.ReadAllText(path);
                var clients = JsonConvert.DeserializeObject<List<Clients>>(contant);
                if (clients == null)
                {
                    clients = new List<Clients>();
                }
                clients.Add(client);
                string json = JsonConvert.SerializeObject(clients);
                System.IO.File.WriteAllText(path, json);

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
        private void Update_Client(List<Clients> clients)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "client.json";
                string json = JsonConvert.SerializeObject(clients);
                System.IO.File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
