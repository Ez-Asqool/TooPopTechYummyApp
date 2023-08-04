using Microsoft.AspNetCore.Mvc;
using YummyApp.Core;
using YummyApp.Core.Models;
using YummyApp.Core.Repositories;
using YummyApp.Core.ViewModels.AdminViewModels;

namespace YummyApp.app.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository<ApplicationUser> _userRepository;

		public HomeController(IUnitOfWork unitOfWork, IUserRepository<ApplicationUser> userRepository)
        {
                _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var chefsNo = _userRepository.Count(x => x.UserType == UserType.Chef && x.Blocked == 0);  

            var eventsNo = _unitOfWork.Events.Count(x => x.Blocked == 0);
            var albumsNo = _unitOfWork.PhotoAlbum.Count(x => x.Blocked == 0);   
            var mealsNo = _unitOfWork.Meals.Count(x => x.Blocked == 0);

            var contactsNo = _unitOfWork.Contacts.Count();
            var repliedContactsNo = _unitOfWork.Contacts.Count(x => x.Blocked == 1);

			var booksNo = _unitOfWork.Book.Count();
			var repliedbooksNo = _unitOfWork.Book.Count(x => x.Blocked == 1);

            var adminIndexVM = new adminIndexVM() 
            { 
                NoOfAlbums = albumsNo,
                NoOfMeals = mealsNo,
                NoOfContacts = contactsNo,
                NoOfBookings = booksNo,
                NoOfEvents = eventsNo,
                NoOfChefs = chefsNo,
                NoOfRepliedBookings = repliedbooksNo,
                NoOfRepliedContacts = repliedContactsNo,
            };

			return View(adminIndexVM);
        }
    }
}
