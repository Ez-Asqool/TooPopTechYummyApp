using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics;
using YummyApp.app.Models;
using YummyApp.Core;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.ViewModels.AdminViewModels;
using YummyApp.Core.ViewModels.HomeViewModels;
using YummyApp.EF.Data;
using YummyApp.app.Services;
using YummyApp.app.Services.Hangfire;
using Microsoft.AspNetCore.SignalR;
using YummyApp.app.Services.Notification;

namespace YummyApp.app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IHubContext<NotificationHub> _hubContext;

        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IMapper mapper, IHubContext<NotificationHub> hubContext/*, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager*/)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hubContext = hubContext;
            //_userManager = userManager;
            //_signInManager = signInManager; 
        }

        public IActionResult Index()
        {

            var album = _unitOfWork.PhotoAlbum.Find(x => x.Status == 1, new string[]{ "Photos" });
            var indexVM = new IndexVM();
            indexVM.PhotoAlbum = album;
            return View(indexVM);
        }

        [HttpPost]
        public void Add(IndexVM indexVM) 
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(indexVM.AddBookVM);

                _unitOfWork.Book.Add(book);
                _unitOfWork.Complete();

                // Send a notification to the admin
                _hubContext.Clients.All.SendAsync("ReceiveNotification", "New table booking received!");

                //return View();
                Response.StatusCode = 200;
            }

        }

        //[HttpGet]
        //[Route("Login")]
        //[AllowAnonymous]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        
        
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