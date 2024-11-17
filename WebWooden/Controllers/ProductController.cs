using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebWooden.Models;


namespace WebWooden.Controllers
{
    public class ProductController : Controller
    {
        private readonly WoodContext _Context;
        public ProductController(WoodContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/product/{alias}-{id}.html")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _Context.TbProducts == null)
            {
                return NotFound();
            }
            var product = await _Context.TbProducts.Where(m => (bool)m.IsActive).Where(m => (bool)m.IsNew)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productReview = _Context.TbProductReviews
                .Where(m => m.ProductId == id && (bool)m.IsActive).ToList();
            ViewBag.productRelated = _Context.TbProducts
                .Where(m => m.ProductId != id && m.CategoryProductId == product.CategoryProductId).Take(5)
                .OrderByDescending(m => m.ProductId).ToList();
            return View(product);
        }



    }
}
