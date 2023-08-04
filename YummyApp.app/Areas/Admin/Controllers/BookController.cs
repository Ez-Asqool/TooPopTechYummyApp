using Microsoft.AspNetCore.Mvc;
using YummyApp.app.Services;
using YummyApp.Core;
using YummyApp.Core.ViewModels.AdminViewModels;

namespace YummyApp.app.Areas.Admin.Controllers
{
    public class BookController : AdminBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public BookController(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            var contacts = _unitOfWork.Book.GetAll();
            return View(contacts);
        }

        [HttpPost]
        public IActionResult AllData()
        {
            return Ok(_unitOfWork.Book.DataTableAlldata(Request));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var bookExists = _unitOfWork.Book.GetById(id);
            if (bookExists == null)
            {
                return NotFound();
            }
            return PartialView("/Areas/Admin/Views/Book/Details.cshtml", bookExists);
        }



        [HttpPost]
        public void Reject(int id)
        {
            var bookExists = _unitOfWork.Book.Find(x => x.Id == id && x.Blocked == 0);
            if (bookExists == null)
            {
                Response.StatusCode = 500; // Set the status code to 404 (Not Found)
                return; // Exit the action without returning any value
            }

            bookExists.Blocked = 1;
            _unitOfWork.Book.Update(bookExists);
            _unitOfWork.Complete();

            _emailService.Send("ez1asqool@gmail.com", "Reject Email", "Hello From Email Service, Sorry We Can't Perform Your Booking. Can You Choose Another Appointment please. ?");


            Response.StatusCode = 200;
            return;

        }


        [HttpPost]
        public void Accept(int id)
        {
            var bookExists = _unitOfWork.Book.Find(x => x.Id == id && x.Blocked == 0);
            if (bookExists == null)
            {
                Response.StatusCode = 500; // Set the status code to 404 (Not Found)
                return; // Exit the action without returning any value
            }

            bookExists.Blocked = 1;
            _unitOfWork.Book.Update(bookExists);
            _unitOfWork.Complete();

            _emailService.Send("ez1asqool@gmail.com", "Accept Email", "Hello From Email Service, You Can Visit Us In The Appointment Specified, You Are Welcome.");


            Response.StatusCode = 200;
            return;

        }


    }
}
