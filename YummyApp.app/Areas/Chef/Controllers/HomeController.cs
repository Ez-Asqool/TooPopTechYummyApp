using Microsoft.AspNetCore.Mvc;

namespace YummyApp.app.Areas.Chef.Controllers
{
    public class HomeController : ChefBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
