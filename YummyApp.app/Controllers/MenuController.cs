using Microsoft.AspNetCore.Mvc;

namespace YummyApp.app.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
