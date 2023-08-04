using Microsoft.AspNetCore.Mvc;
using YummyApp.app.Services;
using YummyApp.Core;
using YummyApp.Core.ViewModels.AdminViewModels;

namespace YummyApp.app.Areas.Admin.Controllers
{
    public class ContactController : AdminBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        public ContactController(IUnitOfWork unitOfWork, IEmailService emailService)
        {
                _unitOfWork = unitOfWork;   
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            var contacts = _unitOfWork.Contacts.GetAll();
            return View(contacts);
        }

        [HttpPost]
        public IActionResult AllData()
        {
            return Ok(_unitOfWork.Contacts.DataTableAlldata(Request));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contactExists = _unitOfWork.Contacts.GetById(id);
            if (contactExists == null)
            {
                return NotFound();
            }
            return PartialView("/Areas/Admin/Views/Contact/Details.cshtml", contactExists);
        }


        [HttpGet]
        public IActionResult Reply(int id)
        {
            var ContactExists = _unitOfWork.Contacts.Find(x => x.Id == id && x.Blocked == 0);
            if (ContactExists == null)
            {
                return NotFound();
            }

            var Reply = new ReplyVM() { ID = id };
            
            return PartialView("/Areas/Admin/Views/Contact/Reply.cshtml",Reply);
        }

        [HttpPost]
        public IActionResult Reply(ReplyVM replyVM)
        {
            var ContactExists = _unitOfWork.Contacts.Find(x => x.Id == replyVM.ID && x.Blocked == 0);
            if (ContactExists == null)
            {
                return NotFound();
            }

            ContactExists.Blocked = 1;
            _unitOfWork.Contacts.Update(ContactExists);
            _unitOfWork.Complete();

            _emailService.Send(ContactExists.Email, replyVM.Subject, replyVM.Body);
            
            TempData["message"] = "Email Sent Successfully.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public void Delete(int id)
        {
            var ContactExists = _unitOfWork.Contacts.Find(x => x.Id == id && x.Blocked == 0);
            if (ContactExists == null)
            {
                Response.StatusCode = 500; // Set the status code to 404 (Not Found)
                return; // Exit the action without returning any value
            }

            ContactExists.Blocked = 1;
            _unitOfWork.Contacts.Update(ContactExists);
            _unitOfWork.Complete();

            

        }


    }
}
