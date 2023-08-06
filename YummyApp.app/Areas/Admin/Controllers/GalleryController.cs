using Microsoft.AspNetCore.Mvc;
using YummyApp.app.Services.FileUploadService;
using YummyApp.Core;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.ViewModels.AdminViewModels;

namespace YummyApp.app.Areas.Admin.Controllers
{
    public class GalleryController : AdminBaseController
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IImageService _imageService;

        public GalleryController(IUnitOfWork unitOfWork, IImageService imageService)
        {
                _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AllData()
        {
            return Ok(_unitOfWork.PhotoAlbum.DataTableAlldata(Request));
        }

        [HttpPost]
        public IActionResult Add(AddGalleryVM galleryVM) 
        {
            if (ModelState.IsValid)
            {
                var photoAlbum = new PhotoAlbum() { Title = galleryVM.Title };
                _unitOfWork.PhotoAlbum.Add(photoAlbum);

                foreach (var item in galleryVM.Photos)
                {
                    var uniqueName = _imageService.uploadImage("GalleryImages", item);
                    var photo = new Photo() { PhotoName = uniqueName, PhotoAlbum = photoAlbum};
                    _unitOfWork.Photo.Add(photo);
                }

                _unitOfWork.Complete();

                TempData["message"] = "New Album Added Successfully";
                return RedirectToAction("Index");

            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult EditStatus(int id) 
        {
            var albumExists = _unitOfWork.PhotoAlbum.Find(x => x.Id == id, new string[] { "Photos" });
            if (albumExists == null)
            {
                return NotFound();
            }

            var album = _unitOfWork.PhotoAlbum.Find(x => x.Status == 1);
            if (album.Title == albumExists.Title)
            {
                TempData["errormessage"] = "Should One Photo Album be In Public Home Page.";
                return RedirectToAction("Index");
            } else 
            {
                TempData["message"] = "Album '"+ albumExists.Title +"' Showen In Public Home Page";
                album.Status = 0;
                albumExists.Status = 1;

                _unitOfWork.PhotoAlbum.Update(album);
                _unitOfWork.PhotoAlbum.Update(albumExists);
                _unitOfWork.Complete(); 
                return RedirectToAction("Index");
            }
              
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var albumExists = _unitOfWork.PhotoAlbum.Find(x => x.Id == id, new string[] { "Photos" });
            if (albumExists == null)
            {
                return NotFound();
            }

            albumExists.Blocked = 1;
            _unitOfWork.PhotoAlbum.Update(albumExists); 

            foreach (var item in albumExists.Photos)
            {
                item.Blocked = 1;
                _unitOfWork.Photo.Update(item);
            }

            _unitOfWork.Complete();
            return Ok(); 
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var albumExists = _unitOfWork.PhotoAlbum.Find(x => x.Id == id, new string[] { "Photos" });
            if (albumExists == null)
            {
                return NotFound();
            }
            var albumDetails = new DetailsGalleryVM();
            albumDetails.Title = albumExists.Title;
            albumDetails.Photos = new List<string>();
            foreach (var item in albumExists.Photos)
            {
                albumDetails.Photos.Add(item.PhotoName);
            }
            return PartialView("/Areas/Admin/Views/Gallery/Details.cshtml", albumDetails);
        }


    }
}
