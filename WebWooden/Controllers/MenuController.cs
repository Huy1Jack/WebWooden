using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWooden.Models;
using static System.Net.WebRequestMethods;

namespace WebWooden.Controllers
{
    public class MenuController : Controller
    {
        private readonly WoodContext _context;
        public MenuController(WoodContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            // Trả về trang "about.html" hoặc View tương ứng
            return View();
        }

        public IActionResult Product()
        {
            // Trả về trang "contact.html" hoặc View tương ứng
            return View();
        }

        public IActionResult News()
        {
            // Trả về trang "services.html" hoặc View tương ứng
            return View();
        }
        public IActionResult Partner()
        {
            // Trả về trang "services.html" hoặc View tương ứng
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult contact(string name, string phone, string email, string massage)
        {
            TbContact contact = new TbContact();
            contact.Name = name;
            contact.Phone = phone;
            contact.Email = email;
            contact.Message = massage;
            contact.CreatedDate = DateTime.Now;
            _context.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("contact");
        }
    }
}
