using Microsoft.AspNetCore.Mvc;
using YummyApp.Core;

namespace YummyApp.app.Controllers
{
    public class EventController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var events = _unitOfWork.Events.GetAll();
            return View(events);  
        }
    }
}
