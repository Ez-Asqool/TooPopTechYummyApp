using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YummyApp.app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminBaseController : Controller
    {
        
    }
}
