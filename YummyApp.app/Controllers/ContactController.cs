using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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

        private readonly IStringLocalizer<ContactController> _Localizer;

        public ContactController(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer<ContactController> stringLocalizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _Localizer = stringLocalizer;   
        }

        [HttpGet]
        public IActionResult Submit()
        {
            //ViewBag.Contact = _Localizer.GetString(nameof(Contact));
            //ViewBag.Contact = _Localizer.GetString("Contact");
            ViewBag.Contact = _Localizer["Contact"];
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


                Response.StatusCode = 200;
                var data = "OK";
                return Ok(data);
            }

            return BadRequest();
        }

    }
}
