using Microsoft.AspNetCore.Mvc;

namespace GuarderiaApp.Controllers
{
    public class ListaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
