using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyApp.Core;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.Repositories;
using YummyApp.Core.ViewModels.HomeViewModels;

namespace YummyApp.app.Controllers
{
    public class ContactController : Controller
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(ContactVM contactVM)
        {
            if (ModelState.IsValid)
            {
                Contact contact = _mapper.Map<Contact>(contactVM);
          
                contact.CreatedDate = DateTime.Now;

                _unitOfWork.Contacts.Add(contact);
                _unitOfWork.Complete();


                ViewBag.msg = "success";
                return View();
            }

            ViewBag.msg = "error";
            return View(contactVM);
        }

    }
}
