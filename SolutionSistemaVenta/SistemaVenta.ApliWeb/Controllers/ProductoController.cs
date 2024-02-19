using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApliWeb.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
