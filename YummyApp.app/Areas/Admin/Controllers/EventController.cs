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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public EventController(IMapper mapper, IWebHostEnvironment hostingEnvironment, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _unitOfWork = unitOfWork;
        }


        //[HttpGet]
        //public IActionResult All()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult AllData()
        {
            return Ok(_unitOfWork.Events.DataTableAlldata(Request));
        }

        //List All Events
        public IActionResult Index()
        {
            //var events = _unitOfWork.Events.GetAll();
            //return View(events);
            return View();
        }


        //Add Event.

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}



        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddEventVM addEventVM)
        {
            if (ModelState.IsValid)
            {
                var newEvent = _mapper.Map<Event>(addEventVM);

                newEvent.ImageName = ImageService.uploadImage("EventImages", addEventVM.Image,  _hostingEnvironment);

                _unitOfWork.Events.Add(newEvent);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));

            }

            return PartialView(addEventVM);
        }


        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Update(int id)
        {
            var eventExists = _unitOfWork.Events.GetById(id);

            if (eventExists == null)
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
                if (eventExists == null)
                {
                    return NotFound();
                }
                else 
                { 
                    _mapper.Map(updateEventVM, eventExists);

                    if (updateEventVM.Image != null)
                    {
                        eventExists.ImageName = ImageService.updateImage("EventImages", updateEventVM.Image, updateEventVM.ImageName, _hostingEnvironment);
                    }

                    _unitOfWork.Events.Update(eventExists);
                    _unitOfWork.Complete();

                    TempData["message"] = "Event Updated Successfully";
                    return RedirectToAction("Index");
                }
            }
            return View(updateEventVM);
        }

        


        [HttpGet]
        public IActionResult Details(int id)
        {
            var eventExists = _unitOfWork.Events.GetById(id);
            if (eventExists == null)
            {
                return NotFound();
            }
            var eventDetails = _mapper.Map<DetailsEventVM>(eventExists);
            return PartialView("/Areas/Admin/Views/Event/Details.cshtml", eventDetails);
        }

        //public IActionResult Details(int id)
        //{
        //    var eventExists = _unitOfWork.Events.GetById(id);
        //    if (eventExists == null)
        //    {
        //        return NotFound();
        //    }
        //    var eventDetails = _mapper.Map<DetailsEventVM>(eventExists);
        //    return View(eventDetails);
        //}



        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var eventExists = _unitOfWork.Events.GetById(id);
        //    if (eventExists == null)
        //    {
        //        return NotFound();
        //    }

        //    var deleteEventVM = _mapper.Map<DeleteEventVM>(eventExists);
        //    return View(deleteEventVM);
        //}


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public void Delete(DeleteEventVM deleteEventVM)
        {
            var deleteEvent = _unitOfWork.Events.GetById(deleteEventVM.Id);

            if (deleteEvent != null)
            {
                _unitOfWork.Events.Delete(deleteEvent);

                ImageService.deleteImage("EventImages", deleteEvent.ImageName, _hostingEnvironment);

                _unitOfWork.Complete();

                //return RedirectToAction("Index");
            }

            //return View(deleteEventVM);
        }

        

    }
}
