using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyApp.app.Services.FileUploadService;
using YummyApp.Core;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.ViewModels.AdminViewModels;

namespace YummyApp.app.Areas.Admin.Controllers
{
    public class TestimonialController : AdminBaseController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        private readonly IImageService _imageService; 



        public TestimonialController(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
                _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
        }

        public IActionResult Index()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult AllData()
        {
            return Ok(_unitOfWork.Testimonials.DataTableAlldata(Request));
        }

        [HttpPost]
        public void Add(AddTestimonialVM testimonialVM) 
        {
            if (ModelState.IsValid)
            {
                var newTestimonial =  _mapper.Map<Testimonial>(testimonialVM);
                var imageName = _imageService.uploadImage("TestimonialsImages", testimonialVM.Image);
                newTestimonial.ImageName = imageName;

                _unitOfWork.Testimonials.Add(newTestimonial);
                _unitOfWork.Complete(); 

                Response.StatusCode = 201;
                return;
            }

            Response.StatusCode = 500;
            return;
        }

        [HttpGet]
        public IActionResult Update(int id) 
        {
            var testimonialExists = _unitOfWork.Testimonials.Find(x => x.Id == id);
            if (testimonialExists == null)
            {
                return NotFound();
            }

            var detailsTestimonials = _mapper.Map<UpdateTestimonialVM>(testimonialExists);
            return PartialView("/Areas/Admin/Views/Testimonial/Update.cshtml", detailsTestimonials);
        }

        [HttpPost]
        public IActionResult Update(UpdateTestimonialVM testimonialVM)
        {
            var testimonialExists = _unitOfWork.Testimonials.Find(x => x.Id == testimonialVM.Id);
            if (testimonialExists == null)
            {
                return NotFound();
            }

            _mapper.Map(testimonialVM, testimonialExists);

            if (testimonialVM.Image != null)
            {
                var imageName = _imageService.updateImage("TestimonialsImages", testimonialVM.Image, testimonialExists.ImageName);
                testimonialExists.ImageName = imageName;
            }

            _unitOfWork.Testimonials.Update(testimonialExists);
            _unitOfWork.Complete();

            TempData["message"] = "Testimonial Updated Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStatus(int id)
        {
            var testimonialExists = _unitOfWork.Testimonials.GetById(id);
            if (testimonialExists == null)
            {
                return NotFound();
            }

            testimonialExists.Status = (testimonialExists.Status == 0) ? 1 : 0;
            _unitOfWork.Testimonials.Update(testimonialExists);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var testimonialExists = _unitOfWork.Testimonials.Find(x => x.Id == id);
            if (testimonialExists == null)
            {
                return NotFound();
            }

            var detailsTestimonials = _mapper.Map<DetailsTestimonialVM>(testimonialExists);
            return PartialView("/Areas/Admin/Views/Testimonial/Details.cshtml", detailsTestimonials);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var testimonialExists = _unitOfWork.Testimonials.Find(x => x.Id == id);
            if (testimonialExists == null)
            {
                return NotFound();
            }

            testimonialExists.Blocked = 1;
            _unitOfWork.Testimonials.Update(testimonialExists);
            _unitOfWork.Complete();

            return Ok();
        }


    }
}
