using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YummyApp.app.Services.FileUploadService;
using YummyApp.Core;
using YummyApp.Core.Models;
using YummyApp.Core.Repositories;
using YummyApp.Core.ViewModels.AdminViewModels;
using YummyApp.EF;
using YummyApp.EF.Data;
using YummyApp.EF.Repositories;

namespace YummyApp.app.Areas.Admin.Controllers
{
    public class ChefController : AdminBaseController
    {

        private readonly IUserRepository<ApplicationUser> _userRepository;

        private readonly IMapper _mapper;

        private IImageService _imageService;

        public ChefController(IUserRepository<ApplicationUser> userRepository, IMapper mapper, IImageService imageService)
        {
            _userRepository = userRepository;
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
            return Ok(_userRepository.DataTableAllData(Request));
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var chefExists = _userRepository.GetById(id);
            if (chefExists == null)
            {
                return NotFound();
            }

            var updateChef = _mapper.Map<UpdateChefVM>(chefExists);
            updateChef.Role = "Chef";

            return View(updateChef);
        }

        [HttpPost]
        public IActionResult Update(UpdateChefVM updateChef)
        {

            //if (ModelState.IsValid)
            if(updateChef.FirstName != null && updateChef.LastName != null && updateChef.Email != null)
            {
                var chefExists = _userRepository.GetById(updateChef.Id);
                if (chefExists == null)
                {
                    return NotFound();
                }

                _mapper.Map(updateChef, chefExists);
                chefExists.UserType = UserType.Chef;

                if(updateChef.Image != null)
                {
                    chefExists.ImageName = _imageService.updateImage("UserImages", updateChef.Image, updateChef.ImageName);
                }

                _userRepository.Update(chefExists);

                TempData["message"] = "Chef Updated Successfully";
                return RedirectToAction("Index");

            }

            return View(updateChef);
        }



        [HttpGet]
        public IActionResult EditStatus(string id) 
        { 
            var chef = _userRepository.GetById(id);
            if(chef == null) {
                return NotFound();
            }
            
            chef.Status = (chef.Status == 0) ? 1 : 0;
            _userRepository.Update(chef);
            return Ok(); 
        }


        [HttpPost]
        public IActionResult Delete(string id) 
        { 
            var deleteChef =  _userRepository.GetById(id);
            if (deleteChef != null)
            {
                deleteChef.Blocked = 1;
                _userRepository.Update(deleteChef);
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var chefExists = _userRepository.GetById(id);
            if (chefExists == null)
            {
                return NotFound();
            }

            var chefDetails = _mapper.Map<DetailsChefVM>(chefExists);
            chefDetails.Role = "Chef";
            return PartialView("/Areas/Admin/Views/Chef/Details.cshtml", chefDetails);
        }

    }
}
