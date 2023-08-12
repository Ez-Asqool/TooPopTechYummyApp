using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyApp.Core;
using YummyApp.Core.Models.AdminModels;
using YummyApp.app.Services.FileUploadService;
using YummyApp.Core.ViewModels.AdminViewModels;

namespace YummyApp.app.Areas.Admin.Controllers
{
    
    public class EventController : AdminBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;   

        public EventController(IMapper mapper, IImageService imageService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        [HttpPost]
        public IActionResult AllData()
        {
            return Ok(_unitOfWork.Events.DataTableAlldata(Request));
        }

        //List All Events
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddEventVM addEventVM)
        {
            if (ModelState.IsValid)
            {
                var newEvent = _mapper.Map<Event>(addEventVM);

                newEvent.ImageName = _imageService.uploadImage("EventImages", addEventVM.Image);

                _unitOfWork.Events.Add(newEvent);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));

            }

            return PartialView(addEventVM);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var eventExists = _unitOfWork.Events.GetById(id);

            if (eventExists == null || eventExists.Blocked == 1)
            {
                return NotFound();
            }
            var updateEventVM = _mapper.Map<UpdateEventVM>(eventExists);
            return PartialView("/Areas/Admin/Views/Event/Update.cshtml", updateEventVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UpdateEventVM updateEventVM)
        {
            if (ModelState.IsValid) 
            { 

                var eventExists = _unitOfWork.Events.GetById(updateEventVM.Id);
                if (eventExists == null || eventExists.Blocked == 1)
                {
                    return NotFound();
                }
                else 
                { 
                    _mapper.Map(updateEventVM, eventExists);

                    if (updateEventVM.Image != null)
                    {
                        eventExists.ImageName = _imageService.updateImage("EventImages", updateEventVM.Image, updateEventVM.ImageName);
                    }

                    _unitOfWork.Events.Update(eventExists);
                    _unitOfWork.Complete();

                    TempData["message"] = "Event Updated Successfully";
                    return RedirectToAction("Index");
                }
            }
            return PartialView("/Areas/Admin/Views/Event/Update.cshtml", updateEventVM);
        }

        


        [HttpGet]
        public IActionResult Details(int id)
        {
            var eventExists = _unitOfWork.Events.GetById(id);
            if (eventExists == null || eventExists.Blocked == 1)
            {
                return NotFound();
            }
            var eventDetails = _mapper.Map<DetailsEventVM>(eventExists);
            return PartialView("/Areas/Admin/Views/Event/Details.cshtml", eventDetails);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteEventVM deleteEventVM)
        {
            var deleteEvent = _unitOfWork.Events.GetById(deleteEventVM.Id);

            if (deleteEvent != null)
            {
                deleteEvent.Blocked = 1;
                _unitOfWork.Events.Update(deleteEvent);
                _unitOfWork.Complete();
                return Ok();
            }

            return NotFound();  
        }

        

    }
}
