using Microsoft.AspNetCore.Mvc;

namespace DoAnBackend.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
