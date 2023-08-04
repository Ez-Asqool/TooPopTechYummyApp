using Microsoft.AspNetCore.Mvc;
using YummyApp.Core;

namespace YummyApp.app.Controllers
{
    public class MenuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuController(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var menue = _unitOfWork.MenuCategory.FindAll(new string[] { "Meals" });
            return View(menue);
        }
        
    }
}
