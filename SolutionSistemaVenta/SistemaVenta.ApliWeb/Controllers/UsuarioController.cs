using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApliWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
