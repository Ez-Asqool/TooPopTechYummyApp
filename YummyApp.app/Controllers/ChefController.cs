using Microsoft.AspNetCore.Mvc;
using YummyApp.Core;
using YummyApp.Core.Models;
using YummyApp.Core.Repositories;

namespace YummyApp.app.Controllers
{
    public class ChefController : Controller
    {

        private readonly IUserRepository<ApplicationUser> _userRepository;

        public ChefController(IUserRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;   
        }

        public IActionResult Index()
        {
            var chefs = _userRepository.GetAll(x => x.UserType == UserType.Chef && x.Blocked == 0 && x.Status == 1);
            return View(chefs);
        }
    }
}
