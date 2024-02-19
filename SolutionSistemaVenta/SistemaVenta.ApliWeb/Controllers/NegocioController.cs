using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApliWeb.Controllers
{
    public class NegocioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
