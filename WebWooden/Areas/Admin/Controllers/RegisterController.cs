using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWooden.Areas.Admin.Models;
using WebWooden.Models;
using WebWooden.Utilities;

namespace WebWooden.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        
        private readonly WoodContext _context;
        public RegisterController(WoodContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(WebWooden.Models.TbUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
           
            //Kiểm tra sự tồn tại của email trong CSDL
            var check = _context.TbUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                //Hiển thị thông báo, có thể làm cách khác
                Function._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");

            }
            // Nếu không có thì thêm vào CSDL
            Function._MessageEmail = string.Empty;
            user.Password = Function.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");

        }
    }
}
