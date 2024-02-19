using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApliWeb.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
