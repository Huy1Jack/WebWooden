using Microsoft.AspNetCore.Mvc;
using WebWooden.Utilities;

namespace WebWooden.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]   
        
        public IActionResult Index()
        {
            //kiểm tra trạng thái đăng nhập
            if(!Function.Islogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}
