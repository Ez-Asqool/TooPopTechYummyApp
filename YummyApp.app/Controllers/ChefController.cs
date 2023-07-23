using Microsoft.AspNetCore.Mvc;

namespace YummyApp.app.Controllers
{
    public class ChefController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
