using Microsoft.AspNetCore.Mvc;

namespace WebWooden.Controllers
{
    public class MenuController : Controller
    {
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
        public IActionResult Contact()
        {
            // Trả về trang "services.html" hoặc View tương ứng
            return View();
        }
    }
}
