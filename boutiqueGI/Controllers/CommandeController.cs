using Microsoft.AspNetCore.Mvc;

namespace boutiqueGI.Controllers
{
    public class CommandeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
