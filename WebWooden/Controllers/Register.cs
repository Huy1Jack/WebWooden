using Microsoft.AspNetCore.Mvc;
using WebWooden.Areas.Admin.Models;
using WebWooden.Models;
using WebWooden.Utilities;

namespace WebWooden.Controllers
{
    public class Register : Controller
    {
        private readonly WoodContext _context;
        public Register(WoodContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TbCustomer user)
        {
            if (user == null)
            {
                return NotFound();
            }

            //Kiểm tra sự tồn tại của email trong CSDL
            var check = _context.TbCustomers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                //Hiển thị thông báo, có thể làm cách khác
                Function._MessageEmailCustomer = "Duplicate Email!";
                return RedirectToAction("Index", "Register");

            }
            // Nếu không có thì thêm vào CSDL
            Function._MessageEmailCustomer = string.Empty;
            user.Password = Function.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");

        }
    }
}

