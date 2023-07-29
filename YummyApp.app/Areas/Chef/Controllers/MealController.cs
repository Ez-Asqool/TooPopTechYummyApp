using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using YummyApp.app.Models;
using YummyApp.app.Services.FileUploadService;
using YummyApp.Core;
using YummyApp.Core.Models;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.ViewModels.ChefViewModels;

namespace YummyApp.app.Areas.Chef.Controllers
{
    public class MealController : ChefBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MealController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AllData()
        {
            string userId = User.Identity.GetUserId();
            return Ok(_unitOfWork.Meals.DataTableAlldata(Request, userId));
        }

        [HttpPost]
        public void Add(AddMealVM mealVM)
        {
            if (ModelState.IsValid)
            {
                var newMeal = _mapper.Map<Meal>(mealVM);

                //add category
                var category = _unitOfWork.MenuCategory.Find(x => x.Name == mealVM.Category);
                newMeal.CategoryId = category.Id;

                //add UserID(Chef)
                string userId = User.Identity.GetUserId();
                newMeal.ApplicationUserId = userId; 

                newMeal.ImageName = ImageService.uploadImage("MealImages", mealVM.Image, _hostingEnvironment);
                _unitOfWork.Meals.Add(newMeal);
                _unitOfWork.Complete();

                Response.StatusCode = 201;
                return;
                //return RedirectToAction("Index");

            }
            Response.StatusCode = 500; 
            return;
        }

        [HttpPost]
        public void Delete(int id)
        {
            var mealExists = _unitOfWork.Meals.GetById(id);
            if (mealExists == null )
            {
                Response.StatusCode = 500; // Set the status code to 404 (Not Found)
                return; // Exit the action without returning any value
            }

            mealExists.Blocked = 1;
            _unitOfWork.Meals.Update(mealExists);
            _unitOfWork.Complete();

            Response.StatusCode = 200;
            return;

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var mealExists = _unitOfWork.Meals.Find(x => x.Id == id, new string[] {"User", "Category"} );
            if (mealExists == null)
            {
                return BadRequest();
            }

            var detailMeal = _mapper.Map<DetailsMealVM>(mealExists);
			return PartialView("/Areas/Chef/Views/Meal/Details.cshtml", detailMeal);
		}





    }
}
