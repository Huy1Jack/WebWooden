using Microsoft.AspNetCore.Mvc;
using WebWooden.Models;
using WebWooden.Utilities;

namespace WebWooden.Controllers
{
    public class Login : Controller
    {
        private readonly WoodContext _context;
        public Login(WoodContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TbCustomer user)
        {
            if (user == null)
            {
                return NotFound();
            }

            // Mã hóa mật khẩu
            string pw = Function.MD5Password(user.Password);

            // Kiểm tra sự tồn tại của email và mật khẩu trong cơ sở dữ liệu
            var check = _context.TbCustomers.Where(m => (m.CustomerName == user.CustomerName) && (m.Password == pw)).FirstOrDefault();

            if (check == null)
            {
                Function._Message = "Invalid UserName or Password!";
                return RedirectToAction("Index", "Login");
            }

            // Đăng nhập thành công
            Function._Message = string.Empty;
            Function._CustomerID = check.CustomerId;
            Function._CustomerName = check.CustomerName ?? string.Empty;
            Function._EmailCustomer = check.Email ?? string.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
