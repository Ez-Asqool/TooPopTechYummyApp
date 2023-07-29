using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YummyApp.app.Areas.Chef.Controllers
{
    [Area("Chef")]
    [Authorize(Roles = "Chef")]
    public class ChefBaseController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
