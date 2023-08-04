using AutoMapper;
using YummyApp.app.Services.FileUploadService;
using YummyApp.app.Services.Hangfire;
using YummyApp.Core;

namespace YummyApp.app.Services
{
    public class HangfireService : IHangfireService
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IImageService _imageService;   

        public HangfireService(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;   

        }

        public async Task DeleteRecordsAsync()
        {
            //delete Events
            var events = _unitOfWork.Events.FindAll(x => x.Blocked == 1);
            if (events != null)
            {
                foreach (var item in events)
                {
                    _imageService.deleteImage("EventImages", item.ImageName);
                    _unitOfWork.Events.Delete(item);
                }

                _unitOfWork.Complete();
            }


            //delete Meals
            var meals = _unitOfWork.Meals.FindAll(x => x.Blocked == 1);
            if (meals != null)
            {
                foreach (var item in meals)
                {
                    _imageService.deleteImage("MealImages", item.ImageName);
                    _unitOfWork.Meals.Delete(item);
                }

                _unitOfWork.Complete();
            }

            //delete PhotoAlbum and Photo


        }

    }
}
