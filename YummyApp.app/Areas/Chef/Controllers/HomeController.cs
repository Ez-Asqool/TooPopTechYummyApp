using Microsoft.AspNetCore.Mvc;

namespace YummyApp.app.Areas.Chef.Controllers
{
    [Area("Chef")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
