using Microsoft.AspNetCore.Mvc;
using WebWooden.Utilities;

namespace WebWooden.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            //kiểm tra trạng thái đăng nhập
            if (!Function.Islogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
        public IActionResult Logout()
        {
            Function._UserID = 0;
            Function._UserName = string.Empty;
            Function._Email = string.Empty;
            Function._Message = string.Empty;
            Function._MessageEmail = string.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}
