using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YummyApp.app.Models;
using YummyApp.EF.Data;

namespace YummyApp.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(ILogger<HomeController> logger/*, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager*/)
        {
            _logger = logger;
            //_userManager = userManager;
            //_signInManager = signInManager; 
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
        
        //[HttpPost]
        //[Route("Login")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(string Email , string Password)
        //{
        //    var user = await _userManager.FindByEmailAsync(Email);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
        //        return View();
        //    }

        //    var result = await _signInManager.PasswordSignInAsync(user, Password, false, false);

        //    return View();
        //}


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}