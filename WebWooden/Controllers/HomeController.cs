using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebWooden.Models;


namespace wooden.Controllers
{
    public class HomeController : Controller
    {
        private readonly WoodContext _Context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(WoodContext context, ILogger<HomeController> logger)
        {
            _Context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.productCategories = _Context.TbProductCategories.ToList();
            ViewBag.tbNews = _Context.TbNews.OrderByDescending(m => m.NewId).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
